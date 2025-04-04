using Diary.Core.Domain.Administration;
using Diary.Core.Domain.Diary;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class HabitDiaryResponse
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }
        public string Description { get; set; }

        public Guid DiaryOwnerId { get; set; }

        public decimal TotalCost { get; set; }

        public List<HabitDiaryLineResponse> Lines { get; set; }   
    }
}
