namespace Eventify.Platform.API.Profiles.Domain.Model.ValueObjects;

public record WebSiteAddress(string Url)
{
    public WebSiteAddress() : this(string.Empty)
    {
    }
}