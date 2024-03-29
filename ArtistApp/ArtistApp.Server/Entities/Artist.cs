﻿namespace ArtistApp.Server.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Album>? Albums { get; set; }
    }
}
