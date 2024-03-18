namespace ArtistApp.Server.Model.TracksDto
{
    public class UpdateTrackDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int AlbumId { get; set; }
    }
}
