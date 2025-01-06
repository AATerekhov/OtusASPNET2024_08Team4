using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Message
{
    public class MagazineLineMessage
    {
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; }
        public decimal Cost { get; set; }
    }
}
