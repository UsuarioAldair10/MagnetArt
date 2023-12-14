using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.MagnetArtSystem.Domain.Repositories;
using MagnetArt.MagnetArtSystem.Domain.Services;
using MagnetArt.MagnetArtSystem.Domain.Services.Comunication;
using MagnetArt.Shared.Domain.Repositories;

namespace MagnetArt.MagnetArtSystem.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
        {
            _providerRepository = providerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Provider> GetByIdAsync(int id)
        {
            var provider = await _providerRepository.FindByIdAsync(id);
            if (provider == null) throw new KeyNotFoundException("Provider not found");
            return provider;
        }

        public async Task<IEnumerable<Provider>> ListAsync()
        {
            return await _providerRepository.ListAsync();
        }

        public async Task<ProviderResponse> SaveAsync(Provider provider)
        {
            var existingProviderWithName = await _providerRepository.FindByNameAsync(provider.Name);

            if (existingProviderWithName != null)
                return new ProviderResponse("The provider's name already exist.");

            var existingProviderWithApiUrl = await _providerRepository.FindByApiUrlAsync(provider.ApiUrl);

            if (existingProviderWithApiUrl != null)
                return new ProviderResponse("The provider's Api Url already exist.");
            if (provider.Apikey == "" && provider.KeyRequired == true)
                return new ProviderResponse("The provider must not have a true required key if the api Key is empty");

            try
            {
                await _providerRepository.AddAsync(provider);
                await _unitOfWork.CompleteAsync();
                return new ProviderResponse(provider);
            }
            catch (Exception e)
            {
                return new ProviderResponse($"An error occurred while saving the provider: {e.Message}");
            }
        }

    }
}
