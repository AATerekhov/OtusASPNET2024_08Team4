using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Exceptions
{
    internal class DoubleHabitRoomException(Room room, Habit habit) : InvalidOperationException($"Room {room.Id} already contains a habit ${habit.Name}")
    {
        public Room Room => room;
        public Habit Habit => habit;
    }  
}
