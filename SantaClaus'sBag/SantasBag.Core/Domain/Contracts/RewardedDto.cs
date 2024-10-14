using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantasBag.Core.Domain.Contracts
{
    public record RewardedDto(string Name, string? Description, int Cost, Guid RoomId);
}
