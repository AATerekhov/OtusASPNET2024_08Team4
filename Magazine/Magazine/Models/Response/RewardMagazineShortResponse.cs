using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineShortResponse
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public Guid MagazineOwnerId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
