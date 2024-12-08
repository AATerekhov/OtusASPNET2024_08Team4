using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Models.RewardMagazineLine
{
    public class RewardMagazineLineFilterDto
    {
        public Guid MagazineId { get; set; }
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
