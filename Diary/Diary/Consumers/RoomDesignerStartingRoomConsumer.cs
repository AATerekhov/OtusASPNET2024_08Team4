using Diary.Core.Domain.Administration;
using Diary.Core.Domain.Diary;
using Diary.DataAccess.Abstractions;
using MassTransit;
using RoomsDesigner.Application.Messages;

namespace Diary.Consumers
{
    public class RoomDesignerStartingRoomConsumer(
           IHabitDiaryRepository diaryRepository,
           IHabitDiaryOwnerRepository diaryOwnerRepository) : IConsumer<StartDiaryMessage>
    {
        private const string _nameOwner = "Participant";
        public async Task Consume(ConsumeContext<StartDiaryMessage> context)
        {
            var message = context.Message;
            var owner = await diaryOwnerRepository.GetByIdAsync(message.DiaryOwnerId, context.CancellationToken);
            if (owner is null)
            {
                owner = new HabitDiaryOwner() { Name = _nameOwner, Id = message.DiaryOwnerId };
                await diaryOwnerRepository.AddAsync(owner, context.CancellationToken);
                await diaryOwnerRepository.SaveChangesAsync(context.CancellationToken);
            }

            var diary = new HabitDiary()
            {
                Id = message.RoomId,
                Description = message.Description,
                DiaryOwnerId = message.DiaryOwnerId,
            };
            await diaryRepository.AddAsync(diary, context.CancellationToken);
            await diaryRepository.SaveChangesAsync(context.CancellationToken);
        }
    }
}
