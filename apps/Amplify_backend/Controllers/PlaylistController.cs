using Amplify_backend.Data;
using Amplify_backend.DTOs;
using Amplify_backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amplify_backend.Controllers
{
    [ApiController]
    [Route("playlists")]
    [Authorize]
    public class PlaylistController : ControllerBase
    {
        private readonly AppDbContext db;
        public PlaylistController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaylists()
        {
            Guid userId = Guid.Parse(User.FindFirst("name")?.Value ?? "");

            try
            {
                var playlists = await db.Playlists.Where(playlist => playlist.userId == userId).ToListAsync();

                if (playlists == null)
                    return NotFound("Did not found any playlist");

                return Ok(playlists);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaylistById()
        {
            Guid userId = Guid.Parse(User.FindFirst("name")?.Value ?? "");
            Guid playlistId = Guid.Parse(HttpContext.Request.RouteValues["id"]?.ToString() ?? "");

            try
            {
                if (userId == Guid.Empty || playlistId == Guid.Empty)
                    return NotFound();

                var playlist = await db.Playlists.Where(playlist => playlist.userId == userId && playlist.id == playlistId).Include(p => p.songs).ThenInclude(ps => ps.song).FirstAsync();

                if (playlist == null)
                    return NotFound("Did not found any playlist");

                var result = new
                {
                    playlist.id,
                    playlist.name,
                    Songs = playlist.songs.Select(ps => new
                    {
                        id = ps.song!.id,
                        title = ps.song.title,
                        artist = ps.song.artist?.name ?? "Unknown",
                        duration = ps.song.durationSeconds
                    })
                };

                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist([FromBody] PlaylistDTO req)
        {
            Guid userId = Guid.Parse(User.FindFirst("name")?.Value ?? "");
            Guid playlistId = Guid.NewGuid();

            try
            {
                Playlists createdPlaylist = new Playlists
                {
                    id = playlistId,
                    userId = userId,
                    name = req.name,
                    description = req.description ?? "",
                    coverImageUrl = req.description ?? "",
                    isPublic = req.isPublic
                };

                if (userId == Guid.Empty || playlistId == Guid.Empty)
                    return NotFound();

                await db.Playlists.AddAsync(createdPlaylist);

                await db.SaveChangesAsync();

                return Ok(createdPlaylist);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePlaylistById()
        {
            Guid playlistId = Guid.Parse(HttpContext.Request.RouteValues["id"]?.ToString() ?? "");

            try
            {
                if (playlistId == Guid.Empty)
                    return NotFound("Playlist id not provided");

                var playlistForDeletion = await db.Playlists.FirstOrDefaultAsync(playlist => playlist.id == playlistId);

                if (playlistForDeletion == null)
                    return NotFound("THe playlist with given id does not exist");

                db.Playlists.Remove(playlistForDeletion);

                await db.SaveChangesAsync();

                return Ok("Playlist Deleted Succesfully");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("{id}/songs")]
        public async Task<IActionResult> AddSongToPlaylist([FromBody] string addedSongId)
        {
            Guid playlistId = Guid.Parse(HttpContext.Request.RouteValues["id"]?.ToString() ?? "");
            Guid songId = Guid.Parse(addedSongId.ToString());

            try
            {
                PlaylistSongs song = new PlaylistSongs
                {
                    playlistId = playlistId,
                    songId = songId
                };

                await db.PlaylistSongs.AddAsync(song);

                await db.SaveChangesAsync();

                return Ok(song);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}/songs")]
        public async Task<IActionResult> RemoveSongFromPlaylist([FromBody] string removedSongId)
        {
            {
                Guid playlistId = Guid.Parse(HttpContext.Request.RouteValues["id"]?.ToString() ?? "");
                Guid songId = Guid.Parse(removedSongId.ToString());

                try
                {
                    PlaylistSongs song = new PlaylistSongs
                    {
                        playlistId = playlistId,
                        songId = songId
                    };

                    db.PlaylistSongs.Remove(song);

                    await db.SaveChangesAsync();

                    return Ok(song);
                }
                catch
                {
                    return StatusCode(500);
                }
            }
        }
    }
}
