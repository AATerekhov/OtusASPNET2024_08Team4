using Magazine.Core.Domain.Magazines;
using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Response
{
    public class RewardMagazineLineResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid MagazineId { get; set; }
        [Required]
        public Guid RewardId { get; set; }
        [Required]
        public required string EventDescription { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }      
    }
}
