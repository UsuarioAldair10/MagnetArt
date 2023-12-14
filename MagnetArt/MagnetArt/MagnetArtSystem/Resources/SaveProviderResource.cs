using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MagnetArt.MagnetArtSystem.Resources
{
    public class SaveProviderResource
    {

        [SwaggerSchema("Provider Name")]
        [Required]
        public string Name { get; set; }
        [SwaggerSchema("ApiUrl")]
        public string ApiUrl { get; set; }
        [SwaggerSchema("KeyRequired")]
        public Boolean KeyRequired { get; set; }
        [SwaggerSchema("Apikey")]
        public string Apikey { get; set; }
    }
}
