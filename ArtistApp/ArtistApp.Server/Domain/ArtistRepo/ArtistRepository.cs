using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;
using ArtistApp.Server.Model.ArtistsDto;
using Microsoft.EntityFrameworkCore;

namespace ArtistApp.Server.Domain.ArtistRepo
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly ArtistDbContext _dbContext;
        public ArtistRepository(ArtistDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetArtistAlbums> GetArtistsWithAlbumsAsync(int id)
        {
            return await _dbContext.Set<Artist>().Include(a => a.Albums)
                .Where(u=>u.Id == id).Select(x=> new GetArtistAlbums
            {
                Id = x.Id,
                Name = x.Name,
                    Albums = x.Albums.ToList()
            }).FirstOrDefaultAsync();
        }
        public async Task<List<ArtistInfo>> GetArtists()
        {
            return await _dbContext.Set<Artist>().Select(x => new ArtistInfo
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<List<ArtistDTO>> GetArtistsWithAlbums()
        {
            return await _dbContext.Set<Artist>().Select(x => new ArtistDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
        }
    }
}