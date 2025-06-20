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
            builder.Entity<Quote>().Property(q => q.EventType).IsRequired().HasConversion(eSocialEventTypeConverter);
            builder.Entity<Quote>().Property(q => q.GuestQuantity).IsRequired();
            builder.Entity<Quote>().Property(q => q.Location).IsRequired();
            builder.Entity<Quote>().Property(q => q.HostId).IsRequired().HasConversion(hostIdConverter);
            builder.Entity<Quote>().Property(q => q.OrganizerId).IsRequired().HasConversion(organizerIdConverter);
            builder.Entity<Quote>().Property(q => q.TotalPrice).IsRequired();
            builder.Entity<Quote>().Property(q => q.Status).IsRequired().HasConversion(eQuoteStatusConverter);
      }
}