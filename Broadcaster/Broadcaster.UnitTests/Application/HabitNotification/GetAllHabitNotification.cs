using AutoFixture.Xunit2;
using Broadcaster.Application.Services.Implementations;
using Broadcaster.UnitTests.Hepls;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterMicroservice.Domain.Repository.Abstractions;
using FluentAssertions;
using Moq;
using Xunit;

namespace Broadcaster.UnitTests.Application.HabitNotification
{
    public class GetAllHabitNotification
    {
        [Theory, AutoMoqData]
        public async Task GetAllHabitNotification_GettingAllHabit_NotBeNull(
            IEnumerable<HabitNotifucationMongo>  habitNotifications,
            [Frozen] Mock<IHabitNotificationRepository> habitNotificationRepositoryMock,
            HabitNotificationService habitNotificationService,
            CancellationToken token)
        {
            //Arrange
            habitNotificationRepositoryMock.Setup(repo => repo.GetAllAsync(token))
                .ReturnsAsync(habitNotifications);
            //Act
            var result = await habitNotificationService.GetAllNotificationsAsync(token);
            //Assert
            result.Should().NotBeNull();
            result?.Count().Should().Be(habitNotifications.Count());
        }
    }
}
