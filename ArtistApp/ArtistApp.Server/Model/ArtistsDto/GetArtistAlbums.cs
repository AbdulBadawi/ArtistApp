using ArtistApp.Server.Entities;

namespace ArtistApp.Server.Model.ArtistsDto
{
    public class GetArtistAlbums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}
