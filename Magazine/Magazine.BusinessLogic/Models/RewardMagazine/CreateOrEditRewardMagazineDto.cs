using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Models.RewardMagazine
{
    public class CreateOrEditRewardMagazineDto
    {
        public Guid RoomId { get; init; }
        public string Description { get; init; }

        public Guid MagazineOwnerId { get; init; }
        public Guid UserId { get; init; }
    }
}
