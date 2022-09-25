using AudioService.Models;

namespace AudioService.DTO.Albums
{
    public class UpdateAlbumDTO
    {
        public int codAlb { get; set; }
        public string titulo { get; set; } = string.Empty;
        public DateTime dataLancamento { get; set; }
        public string genero { get; set; } = string.Empty;
        public Gravadora gravadora { get; set; }
        public List<Artista> artistas { get; set; }
    }
}