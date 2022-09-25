using Microsoft.EntityFrameworkCore;
using AudioService.Models;

namespace AudioService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Artista> Artista { get; set; }
        public DbSet<Gravadora> Gravadora { get; set; }
        public DbSet<Album> Album { get; set; }
        //public DbSet<AlbumPlataforma> albumPlataforma { get; set; }
        //public DbSet<ArtistaAlbum> artistaAlbum { get; set; }
    }
}