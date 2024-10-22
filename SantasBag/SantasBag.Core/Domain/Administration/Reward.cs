using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantasBag.Core.Domain.Administration
{
    public class Reward: BaseEntity
    {
        public required string Name {get; set;}
        public string? Description { get; set;}
        public string? Image { get; set; }
        public required int Cost { get; set;}
        public required Guid RoomId { get; set; }

    }
}
