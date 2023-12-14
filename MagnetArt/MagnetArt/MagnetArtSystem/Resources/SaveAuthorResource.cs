using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MagnetArt.MagnetArtSystem.Resources
{
    public class SaveAuthorResource
    {
        [SwaggerSchema("Author FirstName")]
        [Required]
        public string FirstName { get; set; }
        [SwaggerSchema("Author LastName")]
        [Required]
        public string LastName { get;set; }
        [SwaggerSchema("Author PhotoUrl")]
        public string PhotoUrl { get; set; }
    }
}
