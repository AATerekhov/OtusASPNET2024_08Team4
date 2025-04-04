using Magazine.Core.Domain.Magazines;
using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineLineResponse
    {
        public Guid Id { get; set; }
        public Guid MagazineId { get; set; }
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal Cost { get; set; }
    }
}
