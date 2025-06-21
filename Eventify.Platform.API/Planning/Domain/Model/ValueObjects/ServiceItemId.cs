namespace Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

public record ServiceItemId(Guid Identifier)
{
    public ServiceItemId():this(Guid.NewGuid()){}
};