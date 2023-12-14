using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Resources;
using AutoMapper;

namespace MagnetArt.Shared.Mapping
{
    public class ModelToResourceProfile :Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Author, AuthoreResource>();
            CreateMap<Provider, ProviderResource>();
        }
    }
}
