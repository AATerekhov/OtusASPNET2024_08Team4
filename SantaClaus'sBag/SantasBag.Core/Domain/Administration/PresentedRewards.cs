using SantasBag.Core.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SantasBag.Core.Domain.Administration
{
    internal class PresentedRewards
    {
        public required RewardedDto reward;
        public required Guid buyer;
    }
}
