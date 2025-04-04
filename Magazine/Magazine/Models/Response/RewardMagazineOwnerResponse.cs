using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineOwnerResponse
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public List<RewardMagazineResponse> Magazines { get; set; }
    }
}
