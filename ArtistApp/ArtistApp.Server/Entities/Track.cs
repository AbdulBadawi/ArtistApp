namespace ArtistApp.Server.Entities
{
    public class Track 
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int AlbumId { get; set; }
        public Album? Album { get; set; }
    }

}
