using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Request
{
    public class CreateOrEditRewardMagazineOwnerRequest
    {
        public required string Name { get; init; }
    }
}
