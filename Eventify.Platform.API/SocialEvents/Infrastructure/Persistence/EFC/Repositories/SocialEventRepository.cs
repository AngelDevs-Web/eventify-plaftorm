
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;
using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;
using Eventify.Platform.API.SocialEvents.Domain.Repositories;
using Eventify.Platform.API.SocialEvents.Infrastructure.Persistance.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Platform.API.SocialEvents.Infrastructure.Persistance.EFC.Repositories;

public class SocialEventRepository : BaseRepository<SocialEvent>, ISocialEventRepository
{
    public SocialEventRepository(AppDbContext context) : base(context)
    {
        // Ensure the model is configured for SocialEvent at runtime
        ConfigureSocialEventModel();
    }

    private void ConfigureSocialEventModel()
    {
        // Apply configuration at runtime if not already applied
        var entityType = Context.Model.FindEntityType(typeof(SocialEvent));
        if (entityType == null)
        {
            // Force model rebuild with our configuration
            var modelBuilder = new ModelBuilder();
            modelBuilder.ApplySocialEventsConfiguration();
        }
    }

    public async Task<SocialEvent?> FindByEventTitleAsync(string eventTitle)
    {
        return await Context.Set<SocialEvent>()
            .FirstOrDefaultAsync(se => se.EventTitle == eventTitle);
    }

    public async Task<IEnumerable<SocialEvent>> FindByCustomerNameAsync(string customerName)
    {
        return await Context.Set<SocialEvent>()
            .Where(se => se.NameCustomer.NameCustomer.Contains(customerName))
            .ToListAsync();
    }

    public async Task<IEnumerable<SocialEvent>> FindByLocationAsync(string location)
    {
        return await Context.Set<SocialEvent>()
            .Where(se => se.Location.Contains(location))
            .ToListAsync();
    }

    public async Task<IEnumerable<SocialEvent>> FindByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await Context.Set<SocialEvent>()
            .Where(se => se.EventDate.Date >= startDate && se.EventDate.Date <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<SocialEvent>> FindByStatusAsync(EStatusType status)
    {
        return await Context.Set<SocialEvent>()
            .Where(se => se.Status == status)
            .ToListAsync();
    }
}