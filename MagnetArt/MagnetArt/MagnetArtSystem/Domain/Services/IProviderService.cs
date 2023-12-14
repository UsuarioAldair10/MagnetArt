using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Domain.Services.Comunication;

namespace MagnetArt.MagnetArtSystem.Domain.Services
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> ListAsync();
        Task<ProviderResponse> SaveAsync(Provider provider);
        Task<Provider> GetByIdAsync(int id);
    }
}
