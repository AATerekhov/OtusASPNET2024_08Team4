using Magazine.Core.Domain.BaseTypes;
using Magazine.Core.Domain.Magazines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Core.Domain.Administration
{
    public class RewardMagazineOwner : BaseEntity
    {
        public required string Name { get; set; }

        public List<RewardMagazine> Magazines { get; set; }

        public RewardMagazineOwner()
        {
            Magazines = new List<RewardMagazine>();
        }
    }
}
