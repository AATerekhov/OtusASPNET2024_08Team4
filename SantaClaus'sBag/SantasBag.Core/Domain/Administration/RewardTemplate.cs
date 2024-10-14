using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantasBag.Core.Domain.Administration
{
    internal class RewardTemplate: BaseEntity 
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public int Cost {  get; set; }
        public bool LimitedCount {  get; set; } = false;
        public int? TotalCount { get; set;}

    }
}
