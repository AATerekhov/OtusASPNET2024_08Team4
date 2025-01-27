using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Models.RewardMagazine
{
    public class EditRewardMagazineDto
    {   
        public string Description { get; init; }
        public decimal TotalCost { get; set; }
    }
}
