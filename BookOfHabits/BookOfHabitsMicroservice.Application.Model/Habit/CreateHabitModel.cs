using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class CreateHabitModel
    {
        public Guid RoomId { get; set; }
        public Guid PersonId { get; set; }
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
