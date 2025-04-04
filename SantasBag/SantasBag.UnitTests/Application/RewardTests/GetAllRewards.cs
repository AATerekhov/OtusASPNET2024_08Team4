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
    public class GetAllRewards
    {
        [Theory, AutoMoqData]
        public async Task GetAllRewards_GettingAllRewards_NotBeNull(
           List<Reward> rewards,
           [Frozen] Mock<IRewardsRepository<RewardEntity>> rewardsRepositoryMock,
           RewardsService rewardsService,
           CancellationToken token)
        {
            //Arrange
            rewardsRepositoryMock.Setup(repo => repo.Get(token))
                .ReturnsAsync(rewards);
            //Act
            var result = await rewardsService.GetAllRewards(token);
            //Assert
            result.Should().NotBeNull();
            result?.Count().Should().Be(rewards.Count());
        }
    }
}
