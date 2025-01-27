using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Enums
{
    [Flags]
    [Description("Card interface elements")]
    public enum CardOptions
    {
        [Description("Without options")]
        None = 0,
        [Description("The presence of a changing status")]
        Status = 1,
        [Description("Quantitative indicator")]
        Value = 2,
        [Description("Check boxes")]
        Check = 4,
        [Description("The need for a report, text, comment")]
        Report = 8,
        [Description("Embedded tags")]
        Tags = 16,
        [Description("Positive notation")]
        Positive = 32,
        [Description("Negative notation")]
        Negative = 64,
        [Description("File, Photo, Document")]
        Result = 128,
        All = 255
    }
}
