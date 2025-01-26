using Magazine.Core.Domain.Abstractions;
using Magazine.Core.Domain.Administration;
using Magazine.Core.Domain.Magazines;
using MassTransit;
using RoomsDesigner.Application.Messages;

namespace MagazineHost.Consumers
{
    public class RoomDesignerStartingMagazineConsumer(
        IRewardMagazineRepository magazineRepository,
        IRewardMagazineOwnerRepository magazineOwnerRepository) : IConsumer<StartMagazineMessage>
    {
        private const string _nameOwner = "Mentor";
        public async Task Consume(ConsumeContext<StartMagazineMessage> context)
        {
            var message = context.Message;
            var owner = await magazineOwnerRepository.GetByIdAsync(message.MagazineOwnerId, context.CancellationToken);
            if (owner is null)
            {
                owner = new RewardMagazineOwner() { Name = _nameOwner, Id = message.MagazineOwnerId};
                await magazineOwnerRepository.AddAsync(owner, context.CancellationToken);
                await magazineOwnerRepository.SaveChangesAsync(context.CancellationToken);
            }

            var magazine = new RewardMagazine() 
            {
                Description = message.Description, 
                Id = message.RoomId, 
                MagazineOwnerId = message.MagazineOwnerId
            }; 
            await magazineRepository.AddAsync(magazine, context.CancellationToken);
            await magazineRepository.SaveChangesAsync(context.CancellationToken);
        }
    }
}
