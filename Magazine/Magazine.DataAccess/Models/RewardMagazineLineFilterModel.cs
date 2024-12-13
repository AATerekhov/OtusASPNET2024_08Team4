using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.DataAccess.Models
{
    public class RewardMagazineLineFilterModel
    {
        [Required]
        public Guid MagazineId { get; set; }
        [Required]
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
