using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace ArtistApp.Server.Domain.TrackRepo
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        private readonly ArtistDbContext _dbContext;
        public TrackRepository(ArtistDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TrackDTO>> GetTracksByAlbumIdAsync(int albumId)
        {
            return await _dbContext.Set<Track>().Include(x => x.Album).Where(t => t.AlbumId == albumId).Select(x=> new TrackDTO()
            {
                Id = x.Id,
                AlbumId = x.AlbumId,
                Description = x.Description,
                AlbumName = x.Album.Title,
                Title = x.Title,
            }).ToListAsync();
        }
        public async Task<List<TrackDTO>> GetTracksAsync()
        {
            return await _dbContext.Set<Track>().Include(x=>x.Album).Select(x => new TrackDTO()
            {
                Id = x.Id,
                AlbumId = x.AlbumId,
                AlbumName = x.Album.Title,
                Description = x.Description,
                Title = x.Title,
            }).ToListAsync();
        }
    }
}