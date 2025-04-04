using AutoFixture.Xunit2;
using Moq;
using SantasBag.BusinessLogic.Services;
using SantasBag.Core.Abstractions;
using SantasBag.DataAccess.Entities;
using SantasBag.UnitTests.Helps;
using Xunit;
using SantasBag.Core.Models;
using FluentAssertions;

namespace SantasBag.UnitTests.Application.RewardTests
{
    public class GetReward
    {
        [Theory, AutoMoqData]
        public async Task GetReward_GettingReward_NotBeNull(
           Reward entity,
           [Frozen] Mock<IRewardsRepository<RewardEntity>> rewardsRepositoryMock,
           RewardsService rewardsService,
           CancellationToken token)
        {
            //Arrange
            var id = entity.Id;
            rewardsRepositoryMock.Setup(repo => repo.GetById(id, token))
                .ReturnsAsync(entity);
            //Act
            var result = await rewardsService.GetRewardById(id, token);
            //Assert
            result.Should().NotBeNull();
            result?.Id.Should().Be(id);
        }

        [Theory, AutoMoqData]
        public async Task GetReward_GettingReward_NotFound(
          Guid id,
          [Frozen] Mock<IRewardsRepository<RewardEntity>> rewardsRepositoryMock,
           RewardsService rewardsService,
          CancellationToken token)
        {
            //Arrenge
            Reward? entity = null;
            rewardsRepositoryMock.Setup(repo => repo.GetById(id, token))
                .ReturnsAsync(entity);
            //Act

            var result = await rewardsService.GetRewardById(id, token);
            //Assert

            result.Should().BeNull();
        }
    }
}
