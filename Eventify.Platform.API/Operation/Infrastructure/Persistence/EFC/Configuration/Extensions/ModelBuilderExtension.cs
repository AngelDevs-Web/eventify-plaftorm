using Eventify.Platform.API.Operation.Domain.Model.Aggregates;
using Eventify.Platform.API.Operation.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Platform.API.Operation.infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtension
{
    public static void ApplyOperationConfiguration(this ModelBuilder builder)
    {
        // Operation COntext ORM Mapping Rules
        builder.Entity<Review>().HasKey(r => r.Id);
        builder.Entity<Review>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(r => r.Content).IsRequired();
        builder.Entity<Review>().Property(r => r.Rating).IsRequired();
        builder.Entity<Review>().Property(r => r.ProfileId).HasConversion(p => p.ProfileIdentifier, v => new ProfileId(v));
        builder.Entity<Review>().Property(r => r.SocialEventId)
            .HasConversion(s => s.SocialEventIdentifier, s => new SocialEventId(s));
        
    }
}