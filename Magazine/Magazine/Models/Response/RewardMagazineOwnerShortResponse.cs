using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineOwnerShortResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
