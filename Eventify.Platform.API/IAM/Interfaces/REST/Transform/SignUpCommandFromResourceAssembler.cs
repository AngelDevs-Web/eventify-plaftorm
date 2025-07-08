using Eventify.Platform.API.IAM.Domain.Model.Commands;
using Eventify.Platform.API.IAM.Interfaces.REST.Resources;

namespace Eventify.Platform.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}