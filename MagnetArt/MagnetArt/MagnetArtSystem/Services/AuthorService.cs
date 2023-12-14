using MagnetArt.MagnetArtSystem.Domain.Repositories;
using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Domain.Services;
using MagnetArt.MagnetArtSystem.Domain.Services.Comunication;
using MagnetArt.Shared.Domain.Repositories;
using MagnetArtSystem.Domain.Repositories;

namespace MagnetArt.MagnetArtSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await _authorRepository.ListAsync();
        }
        public async Task<AuthorResponse> SaveAsync(Author author)
        {
            var existingAuthorWithFullName = await _authorRepository.FindByFullNameAsync(author.FirstName, author.LastName);
            if (existingAuthorWithFullName != null)
            {
                return new AuthorResponse("The author's first name and last name already exist.");
            }
           
            var existinexistingAuthorWithNickName = await _authorRepository.FindByNickNameAsync(author.NickName);
            if (existinexistingAuthorWithNickName != null)
            {
                return new AuthorResponse("The author's nickname already exist.");
            }

            try
            {
                await _authorRepository.AddAsync(author);
                await _unitOfWork.CompleteAsync();
                return new AuthorResponse(author);
            }
            catch (Exception e) {
                return new AuthorResponse($"An error ocurred while saving the author: {e.Message}");

            }






        }
    }
}
