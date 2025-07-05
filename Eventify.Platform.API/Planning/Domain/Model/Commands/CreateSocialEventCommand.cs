using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Planning.Domain.Model.Commands;

public record CreateSocialEventCommand(
    
    string EventTitle, DateTime EventDate, string CustomerName, string Location,
    EStatusType Status
    );