namespace Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

public record CustomerName(string NameCustomer)
{
    public CustomerName() : this(string.Empty) { }
}