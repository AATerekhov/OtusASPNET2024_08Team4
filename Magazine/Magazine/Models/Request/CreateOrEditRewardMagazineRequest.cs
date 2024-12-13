using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Request
{
    public class CreateOrEditRewardMagazineRequest
    {
        [Required]
        public Guid RoomId { get; init; }
        public string Description { get; init; }
        [Required]
        public Guid MagazineOwnerId { get; init; }
        [Required]
        public Guid UserId { get; init; }
    }
}
