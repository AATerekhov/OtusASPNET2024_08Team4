using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Models.RewardMagazineLine
{
    public class EditRewardMagazineLineDto
    {
        public required string EventDescription { get; set; }
        public required string ModifiedDate { get; set; }
        public decimal Cost { get; set; }
    }
}
