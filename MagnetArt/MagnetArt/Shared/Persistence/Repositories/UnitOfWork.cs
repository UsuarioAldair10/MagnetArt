using MagnetArt.Shared.Domain.Repositories;
using MagnetArt.Shared.Persistence.Contexts;

namespace MagnetArt.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
