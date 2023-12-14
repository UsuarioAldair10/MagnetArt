namespace MagnetArt.MagnetArtSystem.Domain.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApiUrl { get; set; }
        public Boolean KeyRequired { get; set; }
        public string Apikey { get; set; }
       
    }
}
