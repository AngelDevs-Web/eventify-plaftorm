using Eventify.Platform.API.Profiles.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(
    string FirstName,
    string LastName,
    string Email,
    string Street,
    string Number,
    string City,
    string PostalCode,
    string Country,
    TypeProfile Role);