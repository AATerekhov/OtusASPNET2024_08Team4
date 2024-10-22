using SantasBag.Core.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SantasBag.Core.Domain.Administration
{
    public class PresentedRewards: BaseEntity
    {
        public required RewardedDto reward { get; set; }
        public required Guid buyer { get; set; }
    }
}
