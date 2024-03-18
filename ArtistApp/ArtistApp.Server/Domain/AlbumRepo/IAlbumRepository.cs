using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;
using ArtistApp.Server.Model.AlbumsDto;

namespace ArtistApp.Server.Domain.AlbumRepo
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<List<AlbumDTO>> GetAlbumsWithTracksAsync();
        Task<List<AlbumInfo>> GetAlbums();
    }
}