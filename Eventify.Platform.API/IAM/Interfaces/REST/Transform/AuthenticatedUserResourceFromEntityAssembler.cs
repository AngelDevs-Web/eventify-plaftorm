using Eventify.Platform.API.IAM.Domain.Model.Aggregates;
using Eventify.Platform.API.IAM.Interfaces.REST.Resources;

namespace Eventify.Platform.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}