using Magazine.Core.Domain.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Core.Domain.Magazines
{
    public class RewardMagazineLine : BaseEntity
    {
        public Guid MagazineId { get; set; }
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; }
        public decimal Cost { get; set; }
        public required RewardMagazine Magazine { get; set; }
    }
}
