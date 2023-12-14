using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Domain.Services;
using MagnetArt.MagnetArtSystem.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using MagnetArt.Shared.Extensions;

namespace MagnetArt.MagnetArtSystem.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Authors")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;


    public AuthorsController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AuthoreResource>), 200)]
    public async Task<IEnumerable<AuthoreResource>> GetAllAsync()
    {
        var authors = await _authorService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthoreResource>>(authors);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AuthoreResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerResponse(201, "The author was successfully created.", typeof(AuthoreResource))]
    [SwaggerResponse(400, "The author data is not valid.")]
    public async Task<IActionResult> PostAsync([FromBody] SaveAuthorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var author = _mapper.Map<SaveAuthorResource, Author>(resource);

        var result = await _authorService.SaveAsync(author);

        if (!result.Success)
            return BadRequest(result.Message);

        var authorResource = _mapper.Map<Author, AuthoreResource>(result.Resource);

        return Created(nameof(PostAsync), authorResource);
    }


}

