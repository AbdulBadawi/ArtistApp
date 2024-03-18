namespace ArtistApp.Server.Model
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public int ReleaseYear { get; set; }
    }

}
