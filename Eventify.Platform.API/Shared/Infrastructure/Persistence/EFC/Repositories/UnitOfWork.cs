using Eventify.Platform.API.Shared.Domain.Repositories;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}