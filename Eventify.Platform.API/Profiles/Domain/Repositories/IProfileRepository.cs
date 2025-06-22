using Eventify.Platform.API.Profiles.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.ValueObjects;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Profiles.Domain.Repositories;

public interface IProfileRepository :IBaseRepository<Profile>
{
    Task<Profile?> FindByEmailAsync(EmailAddress email);
}