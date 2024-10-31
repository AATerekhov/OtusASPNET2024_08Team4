using BookOfHabitsMicroservice.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Coins
{
    public class CoinsModel : IModel<Guid>
    {
        public Guid Id { get; init; }    
    }
}
