using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Request
{
    public class CreateOrEditRewardMagazineOwnerRequest
    {
        [Required]
        public required string Name { get; init; }
    }
}
