using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantasBag.Core.Domain.Administration
{
    public class RewardTemplate: BaseEntity 
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public int Cost {  get; set; } = 10;
        public bool LimitedCount {  get; set; } = false;
        public int? TotalCount { get; set;}
        public required Guid RoomId { get; set; }

    }
}
