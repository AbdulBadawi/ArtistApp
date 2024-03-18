using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;

namespace ArtistApp.Server.Domain.TrackRepo
{
    public interface ITrackRepository : IRepository<Track>
    {
        Task<List<TrackDTO>> GetTracksByAlbumIdAsync(int albumId);
        Task<List<TrackDTO>> GetTracksAsync();
    }
}