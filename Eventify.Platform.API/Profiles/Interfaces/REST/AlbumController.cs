using System.Net.Mime;
using Eventify.Platform.API.Profiles.Domain.Model.Commands;
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
    [HttpPost("/api/v1/profiles/{profileId:int}/albums")]
    [SwaggerOperation("Create Album", "Create a new album for a profile.", OperationId = "CreateAlbum")]
    [SwaggerResponse(201, "The album was created.", typeof(AlbumResource))]
    [SwaggerResponse(400, "The album was not created.")]
    public async Task<IActionResult> CreateAlbum(int profileId, CreateAlbumResource resource)
    {
        var command = CreateAlbumCommandFromResourceAssembler.ToCommandFromResource(profileId, resource);
        var album = await albumCommandService.Handle(command);
        if (album is null) return BadRequest();
        var albumResource = AlbumResourceFromEntityAssembler.ToResourceFromEntity(album);
        return CreatedAtAction(nameof(GetAlbumById), new { albumId = album.Id }, albumResource);
    }
    
    [HttpGet]
    [SwaggerOperation("Get All Albums", "Get all albums.", OperationId = "GetAllAlbums")]
    [SwaggerResponse(200, "The albums were found.", typeof(IEnumerable<AlbumResource>))]
    public async Task<IActionResult> GetAllAlbums()
    {
        var query = new GetAllAlbumsQuery();
        var albums = await albumQueryService.Handle(query);
        var resources = albums.Select(AlbumResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
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
    [HttpPut("{albumId:int}")]
    [SwaggerOperation("Update Album", "Update an existing album.", OperationId = "UpdateAlbum")]
    [SwaggerResponse(200, "The album was updated.", typeof(AlbumResource))]
    [SwaggerResponse(404, "The album was not found.")]
    public async Task<IActionResult> UpdateAlbum(int albumId, UpdateAlbumResource resource)
    {
        var command = UpdateAlbumCommandFromResourceAssembler.ToCommandFromResource(albumId, resource);
        var album = await albumCommandService.Handle(command);
        if (album is null) return NotFound();
        var albumResource = AlbumResourceFromEntityAssembler.ToResourceFromEntity(album);
        return Ok(albumResource);
    }

    [HttpDelete("{albumId:int}")]
    [SwaggerOperation("Delete Album", "Delete an album.", OperationId = "DeleteAlbum")]
    [SwaggerResponse(204, "The album was deleted.")]
    [SwaggerResponse(404, "The album was not found.")]
    public async Task<IActionResult> DeleteAlbum(int albumId)
    {
        var command = new DeleteAlbumCommand(albumId);
        var result = await albumCommandService.Handle(command);
        if (!result) return NotFound();
        return NoContent();
    }
}