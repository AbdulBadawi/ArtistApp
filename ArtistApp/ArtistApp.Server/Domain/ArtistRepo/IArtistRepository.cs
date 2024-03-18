using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;
using ArtistApp.Server.Model.ArtistsDto;

namespace ArtistApp.Server.Domain.ArtistRepo
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<GetArtistAlbums> GetArtistsWithAlbumsAsync(int id);
        Task<List<ArtistDTO>> GetArtistsWithAlbums();
        Task<List<ArtistInfo>> GetArtists();
    }
}