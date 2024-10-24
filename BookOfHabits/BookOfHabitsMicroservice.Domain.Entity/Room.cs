using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Room : Entity<Guid>
    {
        private readonly ICollection<Habit> _habits = [];
        private readonly ICollection<Coins> _bags = [];
        public IReadOnlyCollection<Habit> SuggestedHabits => [.. _habits];
        public IReadOnlyCollection<Coins> AssignedCoins => [.. _bags];
        public Person Manager { get; }
        public RoomName Name { get; }
        public DateTime CreateDate { get; }
        public DateTime UpdateDate { get; }
        public Room(Guid id, Person manager, RoomName name, DateTime createDate, DateTime updateDate)
            :base(id)
        {
            Name = name;
            CreateDate = createDate;
            UpdateDate = updateDate;
            Manager = manager;
        }
        public Room(Person manager, RoomName name, DateTime createDate, DateTime updateDate)
            :this(Guid.NewGuid(), manager, name, createDate, updateDate)
        {
                
        }
        protected Room(Guid id) : base(id)
        {
        }
    }
}
