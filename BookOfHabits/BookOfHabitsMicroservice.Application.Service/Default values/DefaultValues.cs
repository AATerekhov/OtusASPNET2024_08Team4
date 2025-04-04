using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.Default_values
{
    public static class DefaultValues
    {
        public static TemplateValues GetDefaultTemplateValues() 
            => new TemplateValues(status: "ToDo;Doing;Done",
                                  titleValue: "Result",
                                  titleCheck: "Tasks",
                                  titleReportField: "Report",
                                  tags: "Achievement;Important;Regular;Ordinary",
                                  titlePositive: "Healthy",
                                  titleNegative: "Damage");
        public static Delay GetDefaultDelay() 
            => new Delay(isAfterATime: false,
                         afterTime: 0,
                         isEndless: true,
                         durationTime: 3600);
        public static Repetition GetDefaultRepetition()
            => new Repetition(maxCountPositive: 5,
                              maxCountNegative: 5,
                              isLimit: false,
                              countLimit: 10);

        public static TimeResetInterval GetDefaultTimeResetInterval()
            => new TimeResetInterval(options: ResetIntervalOptions.EveryDay,
                                     timeTheDay: 43_200,
                                     weekDays: WeekDays.None,
                                     numberDayOfTheMonth: 10);
    }
}
