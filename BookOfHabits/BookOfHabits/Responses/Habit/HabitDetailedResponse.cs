﻿using BookOfHabits.Responses.Card;
using BookOfHabits.Responses.Person;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Responses.Habit
{
    public class HabitDetailedResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public CardDetailedResponse? Card { get; init; }
        public required PersonShortResponse Owner { get; init; }
        public bool IsUsed { get; init; }
        public HabitOptions Options { get; init; }
        public required DelayResponse Delay { get; init; }
        public required TimeResetIntervalResponse TimeResetInterval { get; init; }
        public required RepetitionResponse Repetition { get; init; }
    }
}