using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Request
{
    public class CreateRewardMagazineRequest
    {
        public Guid RoomId { get; init; }
        public string Description { get; init; }
        public Guid MagazineOwnerId { get; init; }
        public Guid UserId { get; init; }

        public decimal TotalCost { get; set; }
    }
}
