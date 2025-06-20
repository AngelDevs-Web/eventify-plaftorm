using Eventify.Platform.API.Profiles.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);