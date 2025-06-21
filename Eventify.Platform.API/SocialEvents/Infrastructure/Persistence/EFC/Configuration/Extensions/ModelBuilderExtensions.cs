using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Platform.API.SocialEvents.Infrastructure.Persistance.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySocialEventsConfiguration(this ModelBuilder builder)
    {
        // SocialEvents Context
        builder.Entity<SocialEvent>().HasKey(se => se.Id);
        builder.Entity<SocialEvent>().Property(se => se.Id).IsRequired().ValueGeneratedOnAdd();
        
        // SocialEventTitle Value Object
        builder.Entity<SocialEvent>().OwnsOne(se => se.Title, t =>
        {
            t.WithOwner().HasForeignKey("Id");
            t.Property(t => t.Title).HasColumnName("EventTitle").IsRequired().HasMaxLength(200);
        });
        
        // SocialEventDate Value Object
        builder.Entity<SocialEvent>().OwnsOne(se => se.EventDate, ed =>
        {
            ed.WithOwner().HasForeignKey("Id");
            ed.Property(ed => ed.Date).HasColumnName("EventDate").IsRequired();
        });
        
        // CustomerName Value Object
        builder.Entity<SocialEvent>().OwnsOne(se => se.NameCustomer, c =>
        {
            c.WithOwner().HasForeignKey("Id");
            c.Property(c => c.NameCustomer).HasColumnName("CustomerFirstName").HasMaxLength(100);
            
        });
        
        // SocialEventPlace Value Object
        builder.Entity<SocialEvent>().OwnsOne(se => se.Place, p =>
        {
            p.WithOwner().HasForeignKey("Id");
            p.Property(p => p.Place).HasColumnName("Location").IsRequired().HasMaxLength(300);
        });
        
        // Status enum configuration
        builder.Entity<SocialEvent>()
            .Property(se => se.Status)
            .IsRequired()
            .HasConversion<string>();
    }
}