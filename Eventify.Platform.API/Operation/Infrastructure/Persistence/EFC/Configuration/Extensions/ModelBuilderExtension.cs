using Eventify.Platform.API.Operation.Domain.Model.Aggregates;
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
        builder.Entity<Review>().OwnsOne(r => r.ProfileId, p =>
        {
            p.WithOwner().HasForeignKey("ProfileId");
            p.Property(p => p.Id).HasColumnName("ProfileId");
        });
        builder.Entity<Review>().OwnsOne(r => r.SocialEventId, s =>
        {
            s.WithOwner().HasForeignKey("SocialEventId");
            s.Property(s => s.Id).HasColumnName("SocialEventId");
        });
    }
}