using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadcaster.Application.Models.Base
{
    public class NotificationMessageModel
    {
        public required string Message { get; init; }
        public required string Sender { get; init; }
        public required string Addressee { get; init; } 
    }
}
