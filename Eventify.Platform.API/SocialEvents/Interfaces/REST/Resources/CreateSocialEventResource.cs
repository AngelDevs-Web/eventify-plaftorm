using System.ComponentModel.DataAnnotations;
using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.SocialEvents.Interfaces.REST.Resources;

public record CreateSocialEventResource(
     string EventTitle,
     DateTime EventDate,
     string CustomerName,
     string Location,
     EStatusType Status
    );
    
    
