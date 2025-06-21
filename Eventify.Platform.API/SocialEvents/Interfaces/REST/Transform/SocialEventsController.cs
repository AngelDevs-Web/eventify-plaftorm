using System.Net.Mime;
using Eventify.Platform.API.SocialEvents.Domain.Model.Commands;
using Eventify.Platform.API.SocialEvents.Domain.Model.Queries;
using Eventify.Platform.API.SocialEvents.Domain.Services;
using Eventify.Platform.API.SocialEvents.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Eventify.Platform.API.SocialEvents.Interfaces.REST.Transform;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Profile Endpoints.")]
public class SocialEventsController : ControllerBase
{
    private readonly ISocialEventCommandService _socialEventCommandService;
    private readonly ISocialEventQueryService _socialEventQueryService;

    public SocialEventsController(
        ISocialEventCommandService socialEventCommandService,
        ISocialEventQueryService socialEventQueryService)
    {
        _socialEventCommandService = socialEventCommandService;
        _socialEventQueryService = socialEventQueryService;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a social event",
        Description = "Creates a social event with the provided information",
        OperationId = "CreateSocialEvent")]
    [SwaggerResponse(201, "The social event was created", typeof(SocialEventResource))]
    [SwaggerResponse(400, "The social event was not created")]
    public async Task<IActionResult> CreateSocialEvent(CreateSocialEventResource resource)
    {
        var createSocialEventCommand = CreateSocialEventCommandFromResourceAssembler.ToCommandFromResource(resource);
        var socialEvent = await _socialEventCommandService.Handle(createSocialEventCommand);
        if (socialEvent is null) return BadRequest();
        var socialEventResource = SocialEventResourceFromEntityAssembler.ToResourceFromEntity(socialEvent);
        return CreatedAtAction(nameof(GetSocialEventById), new { socialEventId = socialEvent.Id }, socialEventResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all social events",
        Description = "Gets all social events",
        OperationId = "GetAllSocialEvents")]
    [SwaggerResponse(200, "The social events were found", typeof(IEnumerable<SocialEventResource>))]
    public async Task<IActionResult> GetAllSocialEvents()
    {
        var getAllSocialEventsQuery = new GetAllSocialEventQuery();
        var socialEvents = await _socialEventQueryService.Handle(getAllSocialEventsQuery);
        var socialEventResources = socialEvents.Select(SocialEventResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(socialEventResources);
    }

    [HttpGet("{socialEventId:int}")]
    [SwaggerOperation(
        Summary = "Gets a social event by id",
        Description = "Gets a social event for a given social event identifier",
        OperationId = "GetSocialEventById")]
    [SwaggerResponse(200, "The social event was found", typeof(SocialEventResource))]
    [SwaggerResponse(404, "The social event was not found")]
    public async Task<IActionResult> GetSocialEventById(int socialEventId)
    {
        var getSocialEventByIdQuery = new GetSocialEventByIdQuery(socialEventId);
        var socialEvent = await _socialEventQueryService.Handle(getSocialEventByIdQuery);
        if (socialEvent == null) return NotFound();
        var socialEventResource = SocialEventResourceFromEntityAssembler.ToResourceFromEntity(socialEvent);
        return Ok(socialEventResource);
    }

    [HttpPut("{socialEventId:int}")]
    [SwaggerOperation(
        Summary = "Updates a social event",
        Description = "Updates a social event with the provided information",
        OperationId = "UpdateSocialEvent")]
    [SwaggerResponse(200, "The social event was updated", typeof(SocialEventResource))]
    [SwaggerResponse(404, "The social event was not found")]
    [SwaggerResponse(400, "The social event was not updated")]
    public async Task<IActionResult> UpdateSocialEvent(int socialEventId, UpdateSocialEventResource resource)
    {
        var updateSocialEventCommand = UpdateSocialEventCommandFromResourceAssembler.ToCommandFromResource(socialEventId, resource);
        var socialEvent = await _socialEventCommandService.Handle(updateSocialEventCommand);
        if (socialEvent is null) return NotFound();
        var socialEventResource = SocialEventResourceFromEntityAssembler.ToResourceFromEntity(socialEvent);
        return Ok(socialEventResource);
    }

    [HttpDelete("{socialEventId:int}")]
    [SwaggerOperation(
        Summary = "Deletes a social event",
        Description = "Deletes a social event with the given identifier",
        OperationId = "DeleteSocialEvent")]
    [SwaggerResponse(204, "The social event was deleted")]
    [SwaggerResponse(404, "The social event was not found")]
    public async Task<IActionResult> DeleteSocialEvent(int socialEventId)
    {
        var deleteSocialEventCommand = new DeleteSocialEventCommand(socialEventId);
        await _socialEventCommandService.Handle(deleteSocialEventCommand);
        return NoContent();
    }

    [HttpGet("customer/{customerName}")]
    [SwaggerOperation(
        Summary = "Gets social events by customer name",
        Description = "Gets all social events for a given customer name",
        OperationId = "GetSocialEventsByCustomerName")]
    [SwaggerResponse(200, "The social events were found", typeof(IEnumerable<SocialEventResource>))]
    public async Task<IActionResult> GetSocialEventsByCustomerName(string customerName)
    {
        var getSocialEventsByCustomerNameQuery = new GetSocialEventByCustomerQuery(customerName);
        var socialEvents = await _socialEventQueryService.Handle(getSocialEventsByCustomerNameQuery);
        var socialEventResources = socialEvents.Select(SocialEventResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(socialEventResources);
    }
}