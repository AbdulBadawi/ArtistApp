using ArtistApp.Server.Domain.AlbumRepo;
using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;
using Microsoft.AspNetCore.Mvc;
using ArtistApp.Server.Model.AlbumsDto;

namespace ArtistApp.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        [HttpGet]
        public async Task<List<AlbumDTO>> GetAlbumsWithTracks()
        {
            return await _albumRepository.GetAlbumsWithTracksAsync();
        }
        [HttpGet]
        public async Task<List<AlbumInfo>> GetAlbums()
        {
            return await _albumRepository.GetAlbums();
        }
        [HttpGet]
        public async Task<AlbumDTO> GetAlbum(int id)
        {
            var album = await _albumRepository.GetByIdAsync(id);
            return new AlbumDTO()
            {
                Id = album.Id,
                Title = album.Title,
                ArtistId = album.ArtistId,
                ReleaseYear = album.ReleaseYear,
                Description = album.Description,
            };
        }
        [HttpPost]
        public async Task AddAlbum([FromBody] CreateAlbumDto request)
        {
            var album = new Album()
            {
                Title = request.Title,
                ArtistId = request.ArtistId,
                ReleaseYear = request.ReleaseYear,
                Description = request.Description
            };
            await _albumRepository.AddAsync(album);
        }
        [HttpPost]
        public async Task UpdateAlbum([FromBody] UpdateAlbumDto request)
        {
            var album = await _albumRepository.GetByIdAsync(request.Id);

            album.Title = request.Title;
            album.ArtistId = request.ArtistId;
            album.ReleaseYear = request.ReleaseYear;
            album.Description = request.Description;

            await _albumRepository.UpdateAsync(album);
        }
        [HttpDelete]
        public async Task DeleteAlbum(int id)
        {
            var album = await _albumRepository.GetByIdAsync(id);
            if (album != null)
            {
                await _albumRepository.DeleteAsync(album);
            }
        }
    }
}
