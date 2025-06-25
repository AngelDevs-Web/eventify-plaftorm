using Eventify.Platform.API.Profiles.Domain.Model.Commands;
using System;
using Eventify.Platform.API.Profiles.Domain.Model.ValueObjects;
using Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Profiles.Interfaces.REST.Transform;

public class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
            resource.FirstName, resource.LastName, resource.Email,
            resource.Street, resource.Number, resource.City,
            resource.PostalCode, resource.Country,
            Enum.TryParse<TypeProfile>(resource.Role, out var role) ? role : TypeProfile.Hoster);
    }
}