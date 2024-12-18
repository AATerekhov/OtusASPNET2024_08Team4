using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Models.RewardMagazineLine
{
    public class CreateRewardMagazineLineDto
    {
        public Guid MagazineId { get; set; }
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }
        public required string ModifiedDate { get; set; }
        public decimal Cost { get; set; }
    }
}
