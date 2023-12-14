using MagnetArt.MagnetArtSystem.Domain.Models;

namespace MagnetArt.MagnetArtSystem.Domain.Repositories
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> ListAsync();
        Task AddAsync(Provider provider);
        Task<Provider> FindByIdAsync(int id);
        Task<Provider> FindByNameAsync(string name);
        Task<Provider> FindByApiUrlAsync(string apiUrl);

    }
}
