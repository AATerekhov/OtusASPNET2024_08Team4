using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Exceptions
{
    internal class DoubleCoinsRoomException(Room room, Coins coins) : InvalidOperationException($"Room {room.Id} already contains a habit ${coins.Habit.Name}")
    {
        public Coins Coins => coins;
        public Room Room => room;
    }
}
