using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;
using ArtistApp.Server.Model.AlbumsDto;
using ArtistApp.Server.Model.ArtistsDto;
using Microsoft.EntityFrameworkCore;

namespace ArtistApp.Server.Domain.AlbumRepo
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly ArtistDbContext _dbContext;
        public AlbumRepository(ArtistDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AlbumDTO>> GetAlbumsWithTracksAsync()
        {
            
            var result = await _dbContext.Set<Album>().Include(a => a.Tracks).Include(b => b.Artist).Select(x => new AlbumDTO
            {
                Id = x.Id,
                Title = x.Title,
                ArtistId = x.ArtistId,
                ReleaseYear = x.ReleaseYear,
                Description = x.Description,
                ArtistName = x.Artist.Name
            }).ToListAsync();
            return result;
        }
        public async Task<List<AlbumInfo>> GetAlbums()
        {
            return await _dbContext.Set<Album>().Select(x => new AlbumInfo
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();
        }
    }
}