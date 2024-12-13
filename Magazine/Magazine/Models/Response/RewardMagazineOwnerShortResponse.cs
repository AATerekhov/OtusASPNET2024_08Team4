using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineOwnerShortResponse
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
