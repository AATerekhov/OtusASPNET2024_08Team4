using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.Default_values
{
    public static class DefaultValues
    {
        public static TemplateValues GetDefaultTemplateValues() 
            => new TemplateValues(titleStatus: "State",
                                  titleValue: "Value result",
                                  titleCheck: "Tasks",
                                  titleReportField: "Text report",
                                  titleTags: "Metks",
                                  titlePositive: "Healthy",
                                  titleNegative: "Damage",
                                  titleFileReceiver: "File report");
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
