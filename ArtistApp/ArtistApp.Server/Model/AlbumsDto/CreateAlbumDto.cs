using ArtistApp.Server.Entities;

namespace ArtistApp.Server.Model.AlbumsDto
{
    public class CreateAlbumDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
    }
}
