using AutoMapper;
using Broadcaster.Application.Models.HabitNotification;
using Broadcaster.Application.Services.Abstractions;
using Broadcaster.Application.Services.Abstractions.Exceptions;
using Broadcaster.Application.Services.Implementations.Base;
using Broadcaster.Application.Services.Implementations.FactoryMethodDomain;
using BroadcasterMicroservice.Domain.Entity;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterMicroservice.Domain.Repository.Abstractions;

namespace Broadcaster.Application.Services.Implementations
{
    public class HabitNotificationService(
        IHabitNotificationRepository notificationRepository,
        IFactory<CreateHabitNotificationModel, HabitNotifucationMongo> factory,
        IMapper mapper) : BaseService, IHabitNotificationService
    {
        public async Task<HabitNotificationModel?> AddNotificationAsync(CreateHabitNotificationModel notificationInfo, CancellationToken token = default)
        {
            HabitNotifucationMongo? entity = factory.FactoryMethod(notificationInfo)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(notificationInfo.Id, nameof(HabitNotification)));
            await notificationRepository.AddAsync(entity, token);
            return mapper.Map<HabitNotificationModel>(entity);
        }

        public async Task<IEnumerable<HabitNotificationModel>> GetAllNotificationsAsync(CancellationToken token = default)
        {
            var notifications = await notificationRepository.GetAllAsync(token);
            return notifications.Select(mapper.Map<HabitNotificationModel>);
        }

        public async Task<HabitNotificationModel?> GetNotificationByIdAsync(Guid id, CancellationToken token = default)
        {
            var entity = await notificationRepository.GetByIdHabitAsync(id, token) ??
                throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitNotification)));
            return mapper.Map<HabitNotificationModel>(entity);
        }

        public async Task DeletedNotification(Guid id, CancellationToken token = default)
        {
            var entity = await notificationRepository.GetByIdHabitAsync(id, token) ??
                throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitNotification)));
            await notificationRepository.DeleteAsync(entity.ObjectId, token);
        }
    }
}
