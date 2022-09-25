using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AudioService.Models
{
    public class Gravadora
    {
        [Key]
        public int codGrav { get; set; }
        public string nomeGrav { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Album> Albums { get; set; }
    }
}