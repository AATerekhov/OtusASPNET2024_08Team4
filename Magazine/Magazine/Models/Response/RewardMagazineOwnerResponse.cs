using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineOwnerResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public List<RewardMagazineResponse> Magazines { get; set; }
    }
}
