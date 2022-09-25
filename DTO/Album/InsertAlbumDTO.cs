namespace AudioService.DTO.Albums
{
    public class InsertAlbumDTO
    {
        public string titulo { get; set; } = string.Empty;
        public DateTime dataLancamento { get; set; }
        public string genero { get; set; } = string.Empty;
        public int codGrav { get; set; }
        public int codArt { get; set; }
    }

}
