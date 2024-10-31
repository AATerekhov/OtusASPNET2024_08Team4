using BookOfHabitsMicroservice.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Room
{
    public class CreateRoomModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public Guid ManagerId { get; init; }
        public DateTime CreateDate { get; init; }
    }
}
