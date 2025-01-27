using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Models.RewardMagazine
{
    public class RewardMagazineFilterDto
    {
        public string? Description { get; init; }
        public Guid RoomId { get; init; }
        public Guid MagazineOwnerId { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
