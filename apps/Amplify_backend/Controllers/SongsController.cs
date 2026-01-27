using Amplify_backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amplify_backend.Controllers
{
    [ApiController]
    [Route("songs")]
    public class SongsController : ControllerBase
    {
        private readonly AppDbContext db;

        public SongsController(AppDbContext context)
        {
            db = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            try
            {
                var songs = await db.Songs.ToListAsync();

                return Ok(songs);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSongById(Guid id)
        {
            try
            {
                var song = await db.Songs.FindAsync(id);
                if (song == null)
                {
                    return NotFound(new { message = "Song not found" });
                }
                return StatusCode(200, song);
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

        [Authorize]
        [HttpGet("{id}/stream")]
        public async Task<IActionResult> StreamSongById(Guid id)
        {
            try
            {
                var foundSong = await db.Songs.FindAsync(id);
                string filePath = foundSong!.filePath;

                if (System.IO.File.Exists(filePath))
                    return NotFound();

                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                return File(stream, "audio/mpeg", enableRangeProcessing: true);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadSong(Guid id)
        {
            return Ok();
        }
    }
}
