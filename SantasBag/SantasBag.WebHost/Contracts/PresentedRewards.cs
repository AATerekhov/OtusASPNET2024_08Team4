using SantasBag.Core.Models;

namespace SantasBag.WebHost.Contracts;

public class PresentedRewards: BaseEntity
{
    public required RewardedDto reward { get; set; }
    public required Guid buyer { get; set; }
}
