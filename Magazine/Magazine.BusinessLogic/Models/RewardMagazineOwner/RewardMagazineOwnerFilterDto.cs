using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Models.RewardMagazineOwner
{
    public class RewardMagazineOwnerFilterDto
    {
        public required string Name { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
