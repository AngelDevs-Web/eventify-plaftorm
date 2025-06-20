using Eventify.Platform.API.Profiles.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.Commands;

namespace Eventify.Platform.API.Profiles.Domain.Services;

public interface IProfileCommandService
{

    Task<Profile?> Handle(CreateProfileCommand command);
}