using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Domain.Repositories;
using MagnetArt.Shared.Persistence.Contexts;
using MagnetArt.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MagnetArt.MagnetArtSystem.Persistence.Repositories
{
    public class ProviderRepository : BaseRepository, IProviderRepository
    {
        public ProviderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Provider>> ListAsync()
        {
            return await _context.Providers.ToListAsync();
        }

        public async Task AddAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
        }


        public async Task<Provider> FindByApiUrlAsync(string apiUrl)
        {
            return await _context.Providers
                .FirstOrDefaultAsync(p => p.ApiUrl == apiUrl);
        }

        public async Task<Provider> FindByNameAsync(string name)
        {
            return await _context.Providers
                .FirstOrDefaultAsync(p => p.Name == name);
        }
        public async Task<Provider> FindByIdAsync(int id)
        {
            return await _context.Providers.FindAsync(id);
        }

    }
}
