using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Request
{
    public class CreateRewardMagazineLineRequest
    {
        public Guid MagazineId { get; set; }
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }
        public required string ModifiedDate { get; set; }
        public decimal Cost { get; set; }
    }
}
