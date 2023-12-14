using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.Shared.Domain.Services.Communication;

namespace MagnetArt.MagnetArtSystem.Domain.Services.Comunication
{
    public class AuthorResponse : BaseResponse<Author>
    {
        public AuthorResponse(string message) : base(message) { }

        public AuthorResponse(Author resource) : base(resource) { }
    }
}
