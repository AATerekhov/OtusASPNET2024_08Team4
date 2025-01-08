using RoomsDesigner.Application.Models.Room;

namespace RoomsDesigner.Application.Service.Abstractions
{
    public interface ILaunchService
    {
        Task StartingCase(LaunchModel launchInfo, CancellationToken token = default);

    }
}
