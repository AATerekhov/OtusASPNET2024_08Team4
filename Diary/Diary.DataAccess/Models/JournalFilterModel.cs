using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Models
{
    public class JournalFilterModel
    {

        [Required]
        public Guid Id { get; init; }

        [Required]
        public string Description { get; init; }
        [Required]
        public Guid RoomId { get; init; }

        [Required]
        public Guid JournalOwnerId { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
