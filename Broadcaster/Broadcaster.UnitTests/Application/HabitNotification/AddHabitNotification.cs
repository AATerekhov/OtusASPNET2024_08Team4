using AutoFixture.Xunit2;
using Broadcaster.Application.Models.HabitNotification;
using Broadcaster.Application.Services.Implementations;
using Broadcaster.Application.Services.Implementations.FactoryMethodDomain;
using Broadcaster.UnitTests.Hepls;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
using FluentAssertions;
using Moq;
using Xunit;

namespace Broadcaster.UnitTests.Application.HabitNotification
{
    public class AddHabitNotification
    {
        [Theory, AutoMoqData]
        public async Task GetHabitNotification_AddingNotofication_NotBeNull(
            CreateHabitNotificationModel createModel,
            HabitNotifucationMongo entity,
            [Frozen] Mock<IFactory<CreateHabitNotificationModel, HabitNotifucationMongo>>  factoryMock,
            HabitNotificationService habitNotificationService,
            CancellationToken token)
        {
            //Arrange
            factoryMock.Setup(repo => repo.FactoryMethod(createModel)).Returns(entity);
            //Act
            var result = await habitNotificationService.AddNotificationAsync(createModel, token);
            //Assert
            result.Should().NotBeNull();
            if (entity.Object is not null)
                result?.Id.Should().Be(entity.Object.Id);
        }
    }
}
