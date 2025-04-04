using System.ComponentModel.DataAnnotations;

namespace MagazineHost.Models.Request
{
    public class EditRewardMagazineLineRequest
    {
        public required string EventDescription { get; set; }
        public required string ModifiedDate { get; set; }
        public decimal Cost { get; set; }
    }
}
