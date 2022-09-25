using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AudioService.Models
{
    public class Artista
    {
        [Key]
        public int codArt { get; set; }
        public string nomeArt { get; set; } = string.Empty;
        
        [JsonIgnore]
        public List<Album> albums { get; set; }
    }
}