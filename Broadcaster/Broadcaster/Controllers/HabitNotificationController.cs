using AutoMapper;
using Broadcaster.Application.Models.HabitNotification;
using Broadcaster.Application.Services.Abstractions;
using Broadcaster.Requests.HabitNotification;
using Broadcaster.Responses.HabitNotification;
using Microsoft.AspNetCore.Mvc;

namespace Broadcaster.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitNotificationController(IHabitNotificationService habitNotificationService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<HabitNotificationShortResponse>> GetAllHabitNotifications()
        {
            var notifications = await habitNotificationService.GetAllNotificationsAsync(HttpContext.RequestAborted);
            return notifications.Select(mapper.Map<HabitNotificationShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<HabitNotificationDetailedResponse> GetHabitNotificationById(Guid id)
        {
            var notification = await habitNotificationService.GetNotificationByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<HabitNotificationDetailedResponse>(notification);
        }

        [HttpPost]
        public async Task<bool> CreateHabitNotification(CreateHabitNotiticationRequest request)
        {
            var notification = await habitNotificationService.AddNotificationAsync(mapper.Map<CreateHabitNotificationModel>(request), HttpContext.RequestAborted);
            return notification switch
            {
                not null => true,
                _ => false
            };
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteHabitNotification(Guid id) => await habitNotificationService.DeletedNotification(id, HttpContext.RequestAborted);

    }
}
