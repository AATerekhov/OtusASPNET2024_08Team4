namespace BookOfHabitsMicroservice.Application.Services.Implementations.Base
{
    public class BaseService
    {
        public static string FormatFullNotFoundErrorMessage(Guid id, string nameOfEntity)
            => $"The {nameOfEntity} with Id {id} has not been found.";
        public static string FormatBadRequestErrorMessage(Guid id, string nameOfEntity)
            => $"The {nameOfEntity} with id: {id} is not active.";
        public static string BadRequestEntityExistsMessage(Guid id, string nameOfEntity)
       => $"The {nameOfEntity} with id:{id} already exists.";
        public static string FormatForbiddenErrorMessage(Guid userId, string nameOfEntity)
            => $"The user {userId} does not have the right to perform the action on {nameOfEntity}.";
    }
}
