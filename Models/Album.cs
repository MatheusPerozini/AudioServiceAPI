using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AudioService.Models
{
    public class Album
    {
        [Key]
        public int codAlb { get; set; }
        public string titulo { get; set; } = string.Empty;
        public DateTime dataLancamento { get; set; }
        public string genero { get; set; } = string.Empty;
        public Gravadora gravadora { get; set; }
        public List<Artista> artistas { get; set; }
    }
}