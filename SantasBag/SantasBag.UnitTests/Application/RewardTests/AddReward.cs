using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SantasBag.BusinessLogic.Services;
using SantasBag.Core.Abstractions;
using SantasBag.Core.Models;
using SantasBag.DataAccess.Entities;
using SantasBag.UnitTests.Helps;
using Xunit;

namespace SantasBag.UnitTests.Application.RewardTests
{
    public class AddReward
    {
        [Theory, AutoMoqData]
        public async Task GetReward_AddingReward_NotThrowAsync(
           RewardEntity createModel,
           Reward entity,
           [Frozen] Mock<IRewardsRepository<RewardEntity>> rewardsRepositoryMock,
           RewardsService rewardsService,
           CancellationToken token)
        {
            //Arrange
            entity.Id = createModel.Id;
            rewardsRepositoryMock.Setup(repo => repo.Create(createModel, token)).ReturnsAsync(createModel.Id);
            //Act
            Func<Task> act = async () => await rewardsService.CreateReward(entity, token);
            //Assert
            await act.Should().NotThrowAsync();
        }
    }
}
