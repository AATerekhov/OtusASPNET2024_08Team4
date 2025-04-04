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
    public class DeletedReward
    {
        [Theory, AutoMoqData]
        public async Task DeletedRewardNotification_DeletedReward_NotBeException(
           Guid id,
           [Frozen] Mock<IRewardsRepository<RewardEntity>> rewardsRepositoryMock,
           RewardsService rewardsService,
           CancellationToken token)
        {
            //Arrange
            rewardsRepositoryMock.Setup(repo => repo.Delete(id, token)).ReturnsAsync(id);
            //Act
            Func<Task> act = async () => await rewardsService.DeleteReward(id, token);
            //Assert
            await act.Should().NotThrowAsync();
        }
    }
}
