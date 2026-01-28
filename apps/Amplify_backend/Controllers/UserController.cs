using Amplify_backend.Data;
using Amplify_backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Amplify_backend.Controllers
{
    [ApiController]
    [Route("user")]
    [Authorize]
    public class UserController: ControllerBase
    {
        private readonly AppDbContext db;

        public UserController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet("likes")]
        public async Task<IActionResult> GetLikedSongs()
        {
            Guid userId = Guid.Parse(User.FindFirst("name")?.Value ?? "");

            try
            {
                var likedSongs = db.LikedSongs.Where(data => data.userId == userId).ToList();

                if (likedSongs == null)
                    return NotFound();

                return Ok(likedSongs);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("likes/{id}")]
        public async Task<IActionResult> AddLikedSong()
        {
            Guid songId = Guid.Parse(HttpContext.Request.RouteValues["id"]?.ToString() ?? "");
            Guid userId = Guid.Parse(User.FindFirst("name")?.Value ?? "");

            try
            {
                if (songId == Guid.Empty || userId == Guid.Empty)
                    return BadRequest();

                var likedSongs = await db.LikedSongs.AddAsync(new LikedSongs
                    {
                        songId = songId,
                        userId = userId
                    });

                await db.SaveChangesAsync();

                return Ok("The song was saved to liked songs!");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("likes/{id}")]
        public async Task<IActionResult> RemoveLikedSong()
        {
            Guid songId = Guid.Parse(HttpContext.Request.RouteValues["id"]?.ToString() ?? "");
            Guid userId = Guid.Parse(User.FindFirst("name")?.Value ?? "");

            try
            {
                if (songId == Guid.Empty || userId == Guid.Empty)
                    return BadRequest();

                var likedSongForRemoval = await db.LikedSongs.FirstOrDefaultAsync(ls => ls.songId == songId && ls.userId == userId);

                if (likedSongForRemoval == null)
                    return NotFound("The song was already unliked");

                db.LikedSongs.Remove(likedSongForRemoval);
                await db.SaveChangesAsync();

                return Ok("The song was unsaved from liked songs!");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
