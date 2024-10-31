using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class InstallCardModel
    {
        public Guid PersonId { get; init; }
        public Guid HabitId { get; init; }
        public Guid TemplateCardId { get; init; }
    }
}
