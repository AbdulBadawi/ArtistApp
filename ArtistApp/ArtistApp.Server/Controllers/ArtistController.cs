using ArtistApp.Server.Domain.ArtistRepo;
using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;
using ArtistApp.Server.Model.ArtistsDto;
using Microsoft.AspNetCore.Mvc;

namespace ArtistApp.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        [HttpGet]
        public async Task<GetArtistAlbums> GetArtistWithAlbums(int id)
        {
            return await _artistRepository.GetArtistsWithAlbumsAsync(id);
        }
        [HttpGet]
        public async Task<List<ArtistDTO>> GetArtistsWithAlbums()
        {
            return await _artistRepository.GetArtistsWithAlbums();
        }
        [HttpGet]
        public async Task<List<ArtistInfo>> GetArtists()
        {
            return await _artistRepository.GetArtists();
        }
        [HttpGet]
        public async Task<ArtistDTO> GetArtist(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            return new ArtistDTO()
            {
                Id = artist.Id,
                Name = artist.Name,
                Description = artist.Description
            };
        }
        [HttpPost]
        public async Task AddArtist([FromBody] CreateArtistDto request)
        {
            var artist = new Artist()
            {
                Name = request.Name,
                Description = request.Description,
            };
            await _artistRepository.AddAsync(artist);
        }
        [HttpPost]
        public async Task UpdateArtist([FromBody] UpdateArtistDto request)
        {
            var artist = await _artistRepository.GetByIdAsync(request.Id);

            artist.Name = request.Name;
            artist.Description = request.Description;

            await _artistRepository.UpdateAsync(artist);
        }
        [HttpDelete]
        public async Task DeleteArtist(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist != null)
            {
                await _artistRepository.DeleteAsync(artist);
            }
        }
    }
}
