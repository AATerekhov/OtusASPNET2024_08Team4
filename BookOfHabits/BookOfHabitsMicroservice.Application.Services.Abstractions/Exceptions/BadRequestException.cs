using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions
{
    public class BadRequestException: Exception
    {
        public BadRequestException()
        {
        }
        public BadRequestException(string message)
            : base(message)
        {
        }
        public BadRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
