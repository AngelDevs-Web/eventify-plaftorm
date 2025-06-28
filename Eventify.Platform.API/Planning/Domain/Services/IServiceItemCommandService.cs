using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Commands;

namespace Eventify.Platform.API.Planning.Domain.Services;

public interface IServiceItemCommandService
{
    public Task<ServiceItem?> Handle(CreateServiceItemCommand command);
    public Task<ServiceItem?> Handle(UpdateServiceItemCommand command);
    public Task Handle(DeleteServiceItemCommand command);
}