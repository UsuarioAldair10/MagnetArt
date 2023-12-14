using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Domain.Services;
using MagnetArt.MagnetArtSystem.Resources;

using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using MagnetArt.Shared.Extensions;

namespace MagnetArt.MagnetArtSystem.Controllers
{

    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Create, read, update and delete Providers")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;


        public ProvidersController(IProviderService providerService, IMapper mapper)
        {
            _providerService = providerService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuthoreResource>), 200)]
        public async Task<IEnumerable<ProviderResource>> GetAllAsync()
        {
            var providers = await _providerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderResource>>(providers);

            return resources;
        }
        [HttpGet("{id}")]
        public async Task<ProviderResource> GetByIdAsync(int id)
        {
            var provider = await _providerService.GetByIdAsync(id);
            var resource = _mapper.Map<Provider, ProviderResource>(provider);
            return resource;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProviderResource), 201)]
        [ProducesResponseType(typeof(List<string>), 400)]
        [ProducesResponseType(500)]
        [SwaggerResponse(201, "The provider was successfully created.", typeof(ProviderResource))]
        [SwaggerResponse(400, "The provider data is not valid.")]
        public async Task<IActionResult> PostAsync([FromBody] SaveProviderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var provider = _mapper.Map<SaveProviderResource, Provider>(resource);

            var result = await _providerService.SaveAsync(provider);

            if (!result.Success)
                return BadRequest(result.Message);

            var providerResource = _mapper.Map<Provider, ProviderResource>(result.Resource);

            return Created(nameof(PostAsync), providerResource);
        }
    }
}