using Diary.Core.Domain.BaseTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.HabitDiaryLine
{
    public class CreateHabitDiaryLineDto
    {
        public Guid DiaryId { get; set; }
        public Guid EntityId { get; set; }
        public EntityType entityType { get; set; }
        public required string EventDescription { get; set; }
        public Status Status { get; set; }
        public required string ModifiedDate { get; set; }
        public decimal Cost { get; set; }
    }
}
