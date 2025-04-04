using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineShortResponse
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }
        public string Description { get; set; }

        public Guid MagazineOwnerId { get; set; }
        public Guid UserId { get; set; }
    }
}
