using AutoFixture.Xunit2;
using FluentAssertions;
using MassTransit;
using Moq;
using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Application.Service.Abstractions.Exceptions;
using RoomsDesigner.Application.Services.Implementations;
using RoomsDesigner.Domain.Entity;
using RoomsDesigner.Domain.Repository.Abstractions;
using RoomsDesigner.UnitTests.Helps;
using Xunit;

namespace RoomsDesigner.UnitTests.Application
{
    public class GetParticipantAsyncTests
    {
        [Theory, AutoMoqData]
        public async Task GetParticipantAsync_GettingCase_NotBeNull(
            Participant participant, 
            [Frozen] Mock<IParticipantRepository> participantRepositoryMock, 
            ParticipantService participantService)
        {
            //Arrange
            var id = participant.Id;
            participantRepositoryMock.Setup(repo => repo.GetParticipantByIdAsync(id, default)).ReturnsAsync(participant);

            //Act
            var result = await participantService.GetParticipantByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result?.Name.Should().Be(participant.Name);
        }

        [Theory, AutoMoqData]
        public async Task GetParticipantAsync_Participant_NotFound(
            Guid id,
            [Frozen] Mock<IParticipantRepository> participantRepositoryMock,
            ParticipantService participantService)
        {
            //Arrange
            Participant? participant = null;
            participantRepositoryMock.Setup(repo => repo.GetParticipantByIdAsync(id, default)).ReturnsAsync(participant);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await participantService.GetParticipantByIdAsync(id));
        }

        [Theory, AutoMoqData]
        public async Task GetParticipantAsync_AddingParticipant_NotBeNull(
            CreateParticipantModel createParticipantModel,
            Case room,
            [Frozen] Mock<ICaseRepository> caseRepositoryMock,
            [Frozen] Mock<IParticipantRepository> participantRepositoryMock,
            [Frozen] Mock<IBusControl> busControlMock,         
            ParticipantService participantService
            )
        {
            //Arrange
            var caseId = createParticipantModel.CaseId;

            caseRepositoryMock.Setup(repo => repo.GetCaseByIdAsync(caseId, default)).ReturnsAsync(room);

            //Act
            var result = await participantService.AddParticipantAsync(createParticipantModel, room.OwnerId);

            //Assert

            result.Should().NotBeNull();
        }

    }
}
