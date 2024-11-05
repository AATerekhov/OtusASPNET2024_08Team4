using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.DiaryOwner
{
    public class JournalOwnerFilterDto
    {

        [Required]
        public Guid Id { get; init; }
        [Required]
        public required string Name { get; init; }
        [Required]
        public required string Email { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
