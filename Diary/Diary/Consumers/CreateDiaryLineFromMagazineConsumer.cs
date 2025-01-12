using Diary.Core.Abstractions;
using Diary.Core.Domain.BaseTypes;
using Diary.Core.Domain.Diary;
using Diary.Core.Exceptions;
using Diary.DataAccess.Abstractions;
using Magazine.Message;
using MassTransit;

namespace Diary.Consumers
{
    public class CreateDiaryLineFromMagazineConsumer(IHabitDiaryRepository     _diaryRepository,
                                                     IHabitDiaryLineRepository _diaryLineRepository) : IConsumer<MagazineLineMessage>

    {
        public async Task Consume(ConsumeContext<MagazineLineMessage> context)
        {
            Console.WriteLine("Hello, consumers");

            var magazineLineMessage = context.Message;

            HabitDiary diary        = await _diaryRepository.GetFirstWhere(r => r.RoomId == magazineLineMessage.RoomId 
                                                                           && r.DiaryOwnerId == magazineLineMessage.UserId);

            var diaryLine = new HabitDiaryLine()
            {
                DiaryId          = diary.Id,
                EntityId         = magazineLineMessage.RewardId,
                EventDescription = magazineLineMessage.EventDescription,
                CreatedDate      = magazineLineMessage.CreatedDate,
                ModifiedDate     = magazineLineMessage.ModifiedDate,
                Cost             = -magazineLineMessage.Cost,
            };
   
     
            await _diaryLineRepository.AddAsync(diaryLine, context.CancellationToken);
            await _diaryLineRepository.SaveChangesAsync(context.CancellationToken);
        }
    }
}
