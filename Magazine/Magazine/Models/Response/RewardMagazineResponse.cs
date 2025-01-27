using Magazine.Core.Domain.Administration;
using Magazine.Core.Domain.Magazines;
using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineResponse
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

        public List<RewardMagazineLineResponse> Lines { get; set; }
    }
}
