using System.Net.Mime;
using Eventify.Platform.API.Profiles.Domain.Model.Queries;
using Eventify.Platform.API.Profiles.Domain.Services;
using Eventify.Platform.API.Profiles.Interfaces.REST.Resources;
using Eventify.Platform.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Eventify.Platform.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Album Endpoints.")]
public class AlbumsController(
    IAlbumCommandService albumCommandService,
    IAlbumQueryService albumQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create Album", "Create a new album for a profile.", OperationId = "CreateAlbum")]
    [SwaggerResponse(201, "The album was created.", typeof(AlbumResource))]
    [SwaggerResponse(400, "The album was not created.")]
    public async Task<IActionResult> CreateAlbum(CreateAlbumResource resource)
    {
        var command = CreateAlbumCommandFromResourceAssembler.ToCommandFromResource(resource);
        var album = await albumCommandService.Handle(command);
        if (album is null) return BadRequest();
        var albumResource = AlbumResourceFromEntityAssembler.ToResourceFromEntity(album);
        return CreatedAtAction(nameof(GetAlbumById), new { albumId = album.Id }, albumResource);
    }

    [HttpGet("{albumId:int}")]
    [SwaggerOperation("Get Album by Id", "Get an album by its identifier.", OperationId = "GetAlbumById")]
    [SwaggerResponse(200, "The album was found.", typeof(AlbumResource))]
    [SwaggerResponse(404, "The album was not found.")]
    public async Task<IActionResult> GetAlbumById(int albumId)
    {
        var query = new GetAlbumByIdQuery(albumId);
        var album = await albumQueryService.Handle(query);
        if (album is null) return NotFound();
        var albumResource = AlbumResourceFromEntityAssembler.ToResourceFromEntity(album);
        return Ok(albumResource);
    }
}