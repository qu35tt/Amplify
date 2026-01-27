using Amplify_backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Amplify_backend.Model;
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
            var userId = User.FindFirst("name")?.Value ?? "";

            try
            {
                var likedSongs = db.LikedSongs.Where(data => data.userId + "" == userId).ToList();

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
            string songId = HttpContext.Request.RouteValues["id"]?.ToString() ?? "";
            var userId = User.FindFirst("name")?.Value ?? "";

            try
            {
                if (songId == string.Empty || userId == string.Empty)
                    return BadRequest();

                var likedSongs = await db.LikedSongs.AddAsync(new LikedSongs
                    {
                        songId = new Guid(songId),
                        userId = new Guid(userId)
                    });

                await db.SaveChangesAsync();

                return Ok("The song was saved to liked songs!");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
