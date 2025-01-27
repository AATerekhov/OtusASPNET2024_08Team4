using Magazine.Core.Domain.Administration;
using Magazine.Core.Domain.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Core.Domain.Magazines
{
    public class RewardMagazine : BaseEntity
    {
        public Guid RoomId { get; set; }

        public required string Description { get; set; }

        public Guid MagazineOwnerId { get; set; }

        public Guid UserId { get; set; }

        public decimal TotalCost { get; set; }

        public List<RewardMagazineLine> Lines { get; set; }
        public RewardMagazineOwner MagazineOwner { get; set; }

        public RewardMagazine()
        {
            Lines = new List<RewardMagazineLine>();
        }
    }
}
