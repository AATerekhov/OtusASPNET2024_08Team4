using AutoFixture.Xunit2;
using BookOfHabits.UnitTests.Hepls;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using FluentAssertions;
using Moq;
using Xunit;

namespace BookOfHabits.UnitTests.Application.CoinsTests
{
    public class GetCoinsAsyncTests
    {
        [Theory, AutoMoqData]
        public async Task GetCoinsAsync_GettingCoins_NotBeNull(
            Coins entity,
            [Frozen] Mock<ICoinsRepository> coinsRepositoryMock,
            CoinsApplicationService coinsApplicationService,
            CancellationToken token)
        {
            //Arrange
            var entityId = entity.Id;
            coinsRepositoryMock.Setup(repo => repo.GetCoinsByIdAsync(entityId, token)).ReturnsAsync(entity);

            //Act
            var result = await coinsApplicationService.GetCoinsByIdAsync(entityId, token);

            //Assert
            result.Should().NotBeNull();
            result?.Id.Should().Be(entity.Id);
        }

        [Theory, AutoMoqData]
        public async Task GetCoinsAsync_GettingCoins_NotFound(
            Guid id, 
            [Frozen] Mock<ICoinsRepository> coinsRepositoryMock, 
            CoinsApplicationService coinsApplicationService,
            CancellationToken token)
        {
            //Arrange
            Coins? entity = null;
            coinsRepositoryMock.Setup(repo => repo.GetCoinsByIdAsync(id, token)).ReturnsAsync(entity);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await coinsApplicationService.GetCoinsByIdAsync(id, token));
        }

        [Theory, AutoMoqData]
        public async Task GetCoinsAsync_GettingCollectionOfCoins_ReturnsExpectedQuantity(
            Guid roomId,
            IEnumerable<Coins> partners,
            [Frozen] Mock<ICoinsRepository> coinsRepositoryMock,
            CoinsApplicationService coinsApplicationService,
            CancellationToken token) 
        {
            //Arrange
            var quantity = partners.Count();
            coinsRepositoryMock
                .Setup(repo => repo.GetAllAsync(x => x.Room.Id.Equals(roomId), $"{nameof(Coins.Room)},{nameof(Coins.Habit)}", false, token))
                .ReturnsAsync(partners);
            //Act
            var result = await coinsApplicationService.GetAllRoomCoinsAsync(roomId, token);
            //Assert
            result.Should().NotBeNull();
            result?.Count().Should().Be(quantity);
        }

    }
}
