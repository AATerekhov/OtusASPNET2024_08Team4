﻿using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Habit
{
    public class TimeResetIntervalRequest
    {
        public ResetIntervalOptions Options { get; init; }
        public int TimeTheDay { get; init; }
        public WeekDays WeekDays { get; init; }
        public int NumberDayOfTheMonth { get; init; }
    }
}