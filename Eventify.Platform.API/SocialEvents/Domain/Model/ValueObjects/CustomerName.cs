namespace Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;

public record CustomerName(string NameCustomer)
{
    public CustomerName() : this(string.Empty) { }
}