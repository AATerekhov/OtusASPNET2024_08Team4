using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Request
{
    public class CreateOrEditRewardMagazineLineRequest
    {
        [Required]
        public Guid MagazineId { get; set; }
        [Required]
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }
        [Required]
        public required string ModifiedDate { get; set; }
        public decimal Cost { get; set; }
    }
}
