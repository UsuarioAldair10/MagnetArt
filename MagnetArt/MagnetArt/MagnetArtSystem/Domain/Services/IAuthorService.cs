using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Domain.Services.Comunication;

namespace MagnetArt.MagnetArtSystem.Domain.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> ListAsync();
        Task<AuthorResponse> SaveAsync(Author author);
    }
}
