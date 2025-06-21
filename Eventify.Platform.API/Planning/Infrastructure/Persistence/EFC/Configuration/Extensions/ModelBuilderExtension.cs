using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eventify.Platform.API.Planning.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtension
{
      public static void ApplyPlanningConfiguration(this ModelBuilder builder)
      {
            //Planning ORM Mapping Rules
            var quoteIdConverter = new ValueConverter<QuoteId, Guid>(
                  v => v.Identifier,
                  v => new QuoteId(v));
            var organizerIdConverter = new ValueConverter<OrganizerId, string>(
                  v => v.Identifier,
                  v => new OrganizerId(v));
            var hostIdConverter = new ValueConverter<HostId, string>(
                  v => v.Identifier,
                  v => new HostId(v));
            
            var eSocialEventTypeConverter = new ValueConverter<ESocialEventType,string>(
                  v=> v.ToString(),
                  v => Enum.Parse<ESocialEventType>(v));
            
            var eQuoteStatusConverter = new ValueConverter<EQuoteStatus,string>(
                  v=> v.ToString(),
                  v => Enum.Parse<EQuoteStatus>(v));
            
            builder.Entity<Quote>().HasKey(q => q.Id);
            builder.Entity<Quote>().Property(q => q.Id).IsRequired().HasConversion(quoteIdConverter);
            builder.Entity<Quote>().Property(q => q.Title).IsRequired();
            builder.Entity<Quote>().Property(q => q.EventDate).IsRequired();
            builder.Entity<Quote>().Property(q => q.EventType).IsRequired().HasConversion(eSocialEventTypeConverter).HasMaxLength(50);
            builder.Entity<Quote>().Property(q => q.GuestQuantity).IsRequired();
            builder.Entity<Quote>().Property(q => q.Location).IsRequired();
            builder.Entity<Quote>().Property(q => q.HostId).IsRequired().HasConversion(hostIdConverter).HasMaxLength(50);
            builder.Entity<Quote>().Property(q => q.OrganizerId).IsRequired().HasConversion(organizerIdConverter).HasMaxLength(50);
            builder.Entity<Quote>().Property(q => q.TotalPrice).IsRequired();
            builder.Entity<Quote>().Property(q => q.Status).IsRequired().HasConversion(eQuoteStatusConverter).HasMaxLength(50);
            
            // ORM Mapping Rules for Service Item
            
            var serviceItemIdConverter = new ValueConverter<ServiceItemId,Guid>(
                  v=> v.Identifier,
                  v => new ServiceItemId(v));
            builder.Entity<ServiceItem>().HasKey(s => s.Id);
            builder.Entity<ServiceItem>().Property(s => s.Id).IsRequired().HasConversion(serviceItemIdConverter);
            builder.Entity<ServiceItem>().Property(s => s.Description).IsRequired();
            builder.Entity<ServiceItem>().Property(s=> s.Quantity).IsRequired();
            builder.Entity<ServiceItem>().Property(s=>s.UnitPrice).IsRequired();
            builder.Entity<ServiceItem>().Property(s=>s.TotalPrice).IsRequired();
            builder.Entity<ServiceItem>().Property(s=>s.QuoteId).HasConversion(quoteIdConverter).HasMaxLength(50);
      }
}