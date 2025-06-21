using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;

namespace Eventify.Platform.API.SocialEvents.Domain.Repositories;

public interface ISocialEventRepository
{
    Task<IEnumerable<SocialEvent>> ListAsync();
    Task AddAsync(SocialEvent socialEvent);
    Task<SocialEvent?> FindByIdAsync(int id);
    void Update(SocialEvent socialEvent);
    void Remove(SocialEvent socialEvent);
}