using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Resources;
using AutoMapper;

namespace MagnetArt.Shared.Mapping
{
    public class ResourceToModelProfile : Profile
    { public ResourceToModelProfile()
        {
            CreateMap<SaveAuthorResource, Author>();
            CreateMap<SaveProviderResource, Provider>();
        }
      
    }
}
