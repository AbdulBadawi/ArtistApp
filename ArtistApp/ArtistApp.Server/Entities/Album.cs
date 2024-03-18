namespace ArtistApp.Server.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public int ReleaseYear { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }

}
