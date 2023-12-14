using MagnetArt.MagnetArtSystem.Domain.Models;

namespace MagnetArtSystem.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> ListAsync();
        Task AddAsync(Author author);
        Task<Author> FindByIdAsync(int id);
        Task<Author> FindByFullNameAsync(string firstName, string lastName);
        Task<Author> FindByNickNameAsync(string nickName);
    }
}
