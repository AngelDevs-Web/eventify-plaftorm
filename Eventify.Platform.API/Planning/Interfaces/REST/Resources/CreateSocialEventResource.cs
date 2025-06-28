using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Planning.Interfaces.REST.Resources;

public record CreateSocialEventResource(
     string EventTitle,
     DateTime EventDate,
     string CustomerName,
     string Location,
     EStatusType Status
    );
    
    
