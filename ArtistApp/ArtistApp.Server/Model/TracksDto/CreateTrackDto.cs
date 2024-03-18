namespace ArtistApp.Server.Model.TracksDto
{
    public class CreateTrackDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int AlbumId { get; set; }
    }
}
