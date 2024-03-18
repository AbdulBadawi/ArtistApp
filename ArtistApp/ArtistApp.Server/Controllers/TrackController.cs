using ArtistApp.Server.Domain.TrackRepo;
using ArtistApp.Server.Entities;
using ArtistApp.Server.Model;
using Microsoft.AspNetCore.Mvc;
using ArtistApp.Server.Model.TracksDto;

namespace ArtistApp.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackRepository _trackRepository;
        public TrackController(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }
        [HttpGet]
        public async Task<List<TrackDTO>> GetTracksByAlbumId(int albumId)
        {
            return await _trackRepository.GetTracksByAlbumIdAsync(albumId);
        }
        [HttpGet]
        public async Task<List<TrackDTO>> GetTracks()
        {
            return await _trackRepository.GetTracksAsync();
        }
        [HttpGet]
        public async Task<TrackDTO> GetTrack(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            return new TrackDTO()
            {
                Id = track.Id,
                AlbumId = track.AlbumId,
                Description = track.Description,
                Title = track.Title,
            };
        }
        [HttpPost]
        public async Task AddTrack([FromBody] CreateTrackDto request)
        {
            var track = new Track()
            {
                Title = request.Title,
                AlbumId = request.AlbumId,
                Description = request.Description
            };
            await _trackRepository.AddAsync(track);
        }
        [HttpPost]
        public async Task UpdateTrack([FromBody] UpdateTrackDto request)
        {
            var track = await _trackRepository.GetByIdAsync(request.Id);

            track.Title = request.Title;
            track.AlbumId = request.AlbumId;
            track.Description = request.Description;
            await _trackRepository.UpdateAsync(track);
        }
        [HttpDelete]
        public async Task DeleteTrack(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            if (track != null)
            {
                await _trackRepository.DeleteAsync(track);
            }
        }
    }
}
