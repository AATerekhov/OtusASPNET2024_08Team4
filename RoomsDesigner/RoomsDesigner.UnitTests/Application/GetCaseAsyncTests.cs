using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using RoomsDesigner.Application.Service.Abstractions.Exceptions;
using RoomsDesigner.Application.Services.Implementations;
using RoomsDesigner.Domain.Entity;
using RoomsDesigner.Domain.Repository.Abstractions;
using RoomsDesigner.UnitTests.Helps;
using Xunit;

namespace RoomsDesigner.UnitTests.Application
{
    public class GetCaseAsyncTests
    {
        [Theory, AutoMoqData]
        public async Task GetCaseAsync_GettingCase_NotBeNull(Case selectCase, [Frozen] Mock<ICaseRepository> caseRepositoryMock, СaseService сaseService)
        {
            //Arrange
            var caseId = selectCase.Id;
            caseRepositoryMock.Setup(repo => repo.GetCaseByIdAsync(caseId, default)).ReturnsAsync(selectCase);
            
            //Act
            var result = await сaseService.GetRoomByIdAsync(caseId);

            //Assert
            result.Should().NotBeNull();
            result?.Name.Should().Be(selectCase.Name);
        }

        [Theory, AutoMoqData]
        public async Task GetCaseAsync_GettingCase_NotFound(Guid caseId, [Frozen] Mock<ICaseRepository> caseRepositoryMock, СaseService сaseService) 
        {
            //Arrange
            Case? roomEntity = null;
            caseRepositoryMock.Setup(repo => repo.GetCaseByIdAsync(caseId, default)).ReturnsAsync(roomEntity);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await сaseService.GetRoomByIdAsync(caseId));
        }
    }
}
