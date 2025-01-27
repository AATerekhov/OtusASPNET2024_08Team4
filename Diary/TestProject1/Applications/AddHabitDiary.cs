using AutoFixture.Xunit2;
using Diary.BusinessLogic.Services.Implementation;
using Diary.DataAccess.Abstractions;
using Diary.UnitTests.Helps;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Diary.UnitTests.Applications
{
    public class AddHabitDiary
    {
        //[Theory, AutoMoqData]
        //public async Task GetHabitNotification_GettingHabit_NotBeNull(
        //    [Frozen] Mock<IHabitDiaryRepository> habitNotificationRepositoryMock,
        //    HabitDiaryService habitDiaryService,
        //    CancellationToken token)
        //{
        //    //Arrange
        //    habitNotificationRepositoryMock.Setup(repo => repo.GetByIdHabitAsync(id, token))
        //        .ReturnsAsync(habitNotification);
        //    //Act
        //    var result = await habitNotificationService.GetNotificationByIdAsync(id, token);
        //    //Assert
        //    result.Should().NotBeNull();
        //    result?.Id.Should().Be(id);
        //}

        //[Theory, AutoMoqData]
        //public async Task GetHabitNotification_GettingHabit_NotFound(
        //    Guid id,
        //    [Frozen] Mock<IHabitNotificationRepository> habitNotificationRepositoryMock,
        //    HabitNotificationService habitNotificationService,
        //    CancellationToken token)
        //{
        //    //Arrenge
        //    HabitNotifucationMongo? entity = null;
        //    habitNotificationRepositoryMock.Setup(repo => repo.GetByIdHabitAsync(id, token))
        //        .ReturnsAsync(entity);
        //    //Act

        //    Func<Task> act = async () => await habitNotificationService.GetNotificationByIdAsync(id, token);
        //    //Assert

        //    await act.Should().ThrowAsync<NotFoundException>();
        //}
    }
}

