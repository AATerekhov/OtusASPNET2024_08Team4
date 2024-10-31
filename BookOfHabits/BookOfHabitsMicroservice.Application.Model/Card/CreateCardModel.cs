using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Card
{
    public class CreateCardModel : ICreateModel
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public CardOptions Options { get; init; }
        public byte[]? Image { get; init; }
        public string[]? TitleCheckElements { get; init; }
    }
}
