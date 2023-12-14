using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Domain.Repositories;
using MagnetArt.Shared.Persistence.Contexts;
using MagnetArt.Shared.Persistence.Repositories;
using MagnetArtSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MagnetArt.MagnetArtSystem.Persistence.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository 
    {
        public AuthorRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
        }

        public async Task<Author> FindByNickNameAsync(string nickName)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(p => p.NickName == nickName);
        }

        public async Task<Author> FindByFullNameAsync(string firstName, string lastName)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(p => p.FirstName == firstName && p.LastName == lastName);
        }

        public async Task<Author> FindByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }
    }
}
