using Diary.Core.Abstractions;
using Diary.Core.Domain.BaseTypes;
using Diary.Core.Domain.Diary;
using Diary.Core.Exceptions;
using Magazine.Message;
using MassTransit;

namespace Diary.Consumers
{
    public class CreateDiaryLineFromMagazineConsumer(IRepository<HabitDiary>     _diaryRepository,
                                                     IRepository<HabitDiaryLine> _diaryLineRepository) : IConsumer<MagazineLineMessage>

    {
        public async Task Consume(ConsumeContext<MagazineLineMessage> context)
        {
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
                Diary            = diary
            };
   
     
            await _diaryLineRepository.AddAsync(diaryLine, context.CancellationToken);
            await _diaryLineRepository.SaveChangesAsync(context.CancellationToken);
        }
    }
}
