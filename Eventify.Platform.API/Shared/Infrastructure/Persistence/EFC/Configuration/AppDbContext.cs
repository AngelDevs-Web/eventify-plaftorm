using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Eventify.Platform.API.Planning.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Eventify.Platform.API.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Apply configuration for the Operation bounded context
        //builder.ApplyOperationConfiguration();
        
        // Apply configuration for the Planning bounded context
        builder.ApplyPlanningConfiguration();
        
        //Apply configuration for the Profiles bounded context
        builder.ApplyProfilesConfiguration();
        
        builder.ApplyAlbumsConfiguration();
        
        builder.ApplyServiceCatalogsConfiguration();
        
        ModelBuilderExtension.ApplyPlanningConfiguration(builder);
        // Use snake case naming convention for the database
        builder.UseSnakeCaseNamingConvention();
    }

}