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
        public int Cost { get; set;}
        public int RoomId { get; set; }

    }
}
