using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.Shared.Domain.Services.Communication;

namespace MagnetArt.MagnetArtSystem.Domain.Services.Comunication
{
    public class ProviderResponse : BaseResponse<Provider>
    {
        public ProviderResponse(string message) : base(message) { }
        public ProviderResponse(Provider resoruce) : base(resoruce) { }
    }
}
