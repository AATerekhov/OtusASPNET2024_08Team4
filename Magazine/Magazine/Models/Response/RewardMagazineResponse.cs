using Magazine.Core.Domain.Administration;
using Magazine.Core.Domain.Magazines;
using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineResponse
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }
        public string Description { get; set; }

        public Guid MagazineOwnerId { get; set; }
        public Guid UserId { get; set; }

        public decimal TotalCost { get; set; }
        public List<RewardMagazineLineResponse> Lines { get; set; }
    }
}
