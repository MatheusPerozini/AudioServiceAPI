using AudioService.Models;

namespace AudioService.DTO.Artistas
{
    public class UpdateArtistaDTO
    {

        public int codArt { get; set; }
        public string nomeArt { get; set; } = string.Empty;
        public List<Album> albums { get; set; }
    }
}