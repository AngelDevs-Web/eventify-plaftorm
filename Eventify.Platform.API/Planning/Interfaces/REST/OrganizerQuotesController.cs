using System.Net.Mime;
using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Queries;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Eventify.Platform.API.Planning.Domain.Services;
using Eventify.Platform.API.Planning.Interfaces.REST.Resources;
using Eventify.Platform.API.Planning.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Eventify.Platform.API.Planning.Interfaces.REST;


[ApiController]
[Route("api/v1/organizers/{organizerId}/quotes")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Organizers")]
public class OrganizerQuotesController(IQuoteQueryService quoteQueryService):ControllerBase
{
    [HttpGet]
    [SwaggerOperation(Summary = "Gets quotes by Organizer Id", Description = "Gets quotes by Organizer Id",
        OperationId = "GetQuotesByOrganizerId")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of quotes ", typeof(IEnumerable<QuoteResource>))]
    public async Task<IActionResult> GetQuotesByOrganizerId([FromRoute] string organizerId)
    {
        var getAllQuotesByOrganizerIdQuery = new GetAllQuotesByOrganizerIdQuery(new OrganizerId(organizerId));
        var quotes = await quoteQueryService.Handle(getAllQuotesByOrganizerIdQuery);
        var quoteResources = quotes.Select(QuoteResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(quoteResources);
    }
}