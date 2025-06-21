using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;
using Eventify.Platform.API.SocialEvents.Domain.Model.Queries;

namespace Eventify.Platform.API.SocialEvents.Domain.Services;

public interface ISocialEventQueryService
{
    Task<IEnumerable<SocialEvent>> Handle(GetAllSocialEventQuery query);
    Task<SocialEvent?> Handle(GetSocialEventByIdQuery query);
    Task<IEnumerable<SocialEvent>> Handle(GetSocialEventByCustomerQuery query);
    Task<IEnumerable<SocialEvent>> Handle(GetSocialEventByLocationQuery query);
    Task<IEnumerable<SocialEvent>> Handle(GetSocialEventByTitleQuery query);
    Task<IEnumerable<SocialEvent>> Handle(GetSocialEventByStatusQuery query);
}