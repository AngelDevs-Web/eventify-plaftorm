namespace Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;

/**
 * Represents a unique identifier for a social event.
 * This value object encapsulates a GUID to ensure that each social event has a unique ID.
 */

public record SocialEventId(Guid id)
{
    public SocialEventId() : this(Guid.NewGuid()) {}

}
