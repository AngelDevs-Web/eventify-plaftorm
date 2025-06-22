using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;
using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.SocialEvents.Interfaces.ACL;

public interface ISocialEventContextFacade
{
    Task<int> CreateSocialEventAsync(string eventTitle, DateTime eventDate, string customerName, string location, EStatusType status);
    Task<SocialEvent?> GetSocialEventByIdAsync(int socialEventId);
    Task<IEnumerable<SocialEvent>> GetAllSocialEventsAsync();
    Task<bool> UpdateSocialEventAsync(int socialEventId, string eventTitle, DateTime eventDate, string customerName, string location, EStatusType status);
    Task<bool> DeleteSocialEventAsync(int socialEventId);
    Task<IEnumerable<SocialEvent>> GetSocialEventsByCustomerNameAsync(string customerName);
    
}