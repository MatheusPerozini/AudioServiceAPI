using AudioService.Models;

namespace AudioService.DTO.Gravadoras
{
    public class UpdateGravadoraDTO
    {
        public int codGrav { get; set; }
        public string nomeGrav { get; set; } = string.Empty;
        public List<Album> Albums { get; set; }
    }
}