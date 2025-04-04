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
    public class GetHabitNotification
    {
        [Theory, AutoMoqData]
        public async Task GetHabitNotification_GettingHabit_NotBeNull(
            HabitNotifucationMongo habitNotification,
            [Frozen] Mock<IHabitNotificationRepository> habitNotificationRepositoryMock,
            HabitNotificationService habitNotificationService,
            CancellationToken token)
        {
            //Arrange
            var id = habitNotification.Object.Id;
            habitNotificationRepositoryMock.Setup(repo => repo.GetByIdHabitAsync(id, token))
                .ReturnsAsync(habitNotification);
            //Act
            var result = await habitNotificationService.GetNotificationByIdAsync(id, token);
            //Assert
            result.Should().NotBeNull();
            result?.Id.Should().Be(id);
        }

        [Theory, AutoMoqData]
        public async Task GetHabitNotification_GettingHabit_NotFound(
            Guid id,
            [Frozen] Mock<IHabitNotificationRepository> habitNotificationRepositoryMock,
            HabitNotificationService habitNotificationService,
            CancellationToken token)
        {
            //Arrenge
            HabitNotifucationMongo? entity = null;
            habitNotificationRepositoryMock.Setup(repo => repo.GetByIdHabitAsync(id, token))
                .ReturnsAsync(entity);
            //Act

            Func<Task> act = async () => await habitNotificationService.GetNotificationByIdAsync(id, token);
            //Assert

            await act.Should().ThrowAsync<NotFoundException>();
        }
    }
}
