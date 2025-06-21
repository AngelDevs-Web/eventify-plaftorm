using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.SocialEvents.Domain.Model.Queries;

public record GetSocialEventByStatusQuery(EStatusType Status);