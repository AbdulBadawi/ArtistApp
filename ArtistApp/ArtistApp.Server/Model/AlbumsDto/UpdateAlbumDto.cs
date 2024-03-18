namespace ArtistApp.Server.Model.AlbumsDto
{
    public class UpdateAlbumDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
    }
}
