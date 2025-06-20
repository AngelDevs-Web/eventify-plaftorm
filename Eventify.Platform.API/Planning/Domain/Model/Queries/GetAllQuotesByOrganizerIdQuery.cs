using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Planning.Domain.Model.Queries;

public record GetAllQuotesByOrganizerIdQuery(OrganizerId OrganizerId);