using AutoFixture.Xunit2;
using Broadcaster.Application.Services.Abstractions.Exceptions;
using Broadcaster.Application.Services.Implementations;
using Broadcaster.UnitTests.Hepls;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterMicroservice.Domain.Repository.Abstractions;
using FluentAssertions;
using Moq;
using Xunit;

namespace Broadcaster.UnitTests.Application.HabitNotification
{
    public class DeletedHabitNotification
    {
        [Theory, AutoMoqData]
        public async Task DeletedHabitNotification_DeletedHabit_NotBeException(
            Guid id,
            HabitNotifucationMongo entity,
            [Frozen] Mock<IHabitNotificationRepository> habitNotificationRepositoryMock,
            HabitNotificationService habitNotificationService,
            CancellationToken token)
        {
            //Arrange
            habitNotificationRepositoryMock.Setup(repo => repo.GetByIdHabitAsync(id, token)).ReturnsAsync(entity);
            //Act
            Func<Task> act = async () => await habitNotificationService.DeletedNotification(id, token);
            //Assert
            await act.Should().NotThrowAsync();
        }

        [Theory, AutoMoqData]
        public async Task DeletedHabitNotification_DeletedHabit_NotFound(
           Guid id,
           [Frozen] Mock<IHabitNotificationRepository> habitNotificationRepositoryMock,
           HabitNotificationService habitNotificationService,
           CancellationToken token)
        {
            //Arrange
            HabitNotifucationMongo? entity = null;
            habitNotificationRepositoryMock.Setup(repo => repo.GetByIdHabitAsync(id, token)).ReturnsAsync(entity);
            //Act
            Func<Task> act = async () => await habitNotificationService.DeletedNotification(id, token);
            //Assert
            await act.Should().ThrowAsync<NotFoundException>();
        }
    }
}
