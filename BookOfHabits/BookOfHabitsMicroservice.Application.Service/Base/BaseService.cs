﻿namespace BookOfHabitsMicroservice.Application.Services.Base
{
    public class BaseService
    {
        public string FormatFullNotFoundErrorMessage(Guid id, string nameOfEntity)
            => $"The {nameOfEntity} with Id {id} has not been found.";
        public string FormatBadRequestErrorMessage(Guid id, string nameOfEntity)
            => $"The {nameOfEntity} with id: {id} is not active.";
    }
}