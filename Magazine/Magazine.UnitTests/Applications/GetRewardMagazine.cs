using AutoFixture.Xunit2;
using FluentAssertions;
using Magazine.BusinessLogic.Services.Implementatios;
using Magazine.Core.Domain.Abstractions;
using Magazine.Core.Domain.Magazines;
using Magazine.Core.Exceptions;
using Magazine.UnitTests.Helps;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.UnitTests.Applications
{
    public class GetRewardMagazine
    {
        [Theory, AutoMoqData]
        public async Task GetByIdAsync_DiaryExists_ReturnsDiary(
        Guid id,
        RewardMagazine rewardMagazine,
        [Frozen] Mock<IRewardMagazineRepository> habitMagazineRepositoryMoc,
        RewardMagazineService habitDiaryService,
        CancellationToken token)
        {
            // Arrange
            rewardMagazine.Id = id;
            habitMagazineRepositoryMoc.Setup(repo => repo.GetByIdAsync(id, token, It.IsAny<string>()))
                .ReturnsAsync(rewardMagazine);

            // Act
            var result = await habitDiaryService.GetByIdAsync(id, token);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
        }

        [Theory, AutoMoqData]
        public async Task GetByIdAsync_RecordNotFound_ThrowsNotFoundException(
        Guid id,
        [Frozen] Mock<IRewardMagazineRepository> habitMagazineRepositoryMock,
        RewardMagazineService habitDiaryService,
        CancellationToken token)
        {
            // Arrange
            RewardMagazine? rewardMagazine = null;
            habitMagazineRepositoryMock.Setup(repo => repo.GetByIdAsync(id, token, It.IsAny<string>()))
                                    .ReturnsAsync(rewardMagazine);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(
                () => habitDiaryService.GetByIdAsync(id, token));

            Func<Task> act = async () => await habitDiaryService.GetByIdAsync(id, token);
            //Assert

            await act.Should().ThrowAsync<NotFoundException>();

        }
    }
}
