using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.JournalOwner
{
    public class CreateOrEditHabitDiaryOwnerDto
    {
        public required string Name { get; init; }
        public required string Email { get; init; }
    }
}
