﻿namespace Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(
    string FirstName,
    string LastName,
    string Email,
    string Street,
    string Number,
    string City,
    string PostalCode,
    string Country,
    string PhoneNumber,
    string WebSite,
    string Biography,
    string Role);