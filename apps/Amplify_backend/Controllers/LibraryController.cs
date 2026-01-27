using Amplify_backend.Data;
using Amplify_backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amplify_backend.Controllers
{
    [ApiController]
    [Route("library")]
    public class LibraryController: ControllerBase
    {
        private readonly AppDbContext db;

        public LibraryController(AppDbContext context)
        {
            db = context;
        }

        [Authorize]
        [HttpGet("artists")]
        public async Task<IActionResult> GetArtists()
        {
            try
            {
                var artists = db.Artists
                    .Select(artist => new ArtistDTO
                    {
                        id = artist.id,
                        name = artist.name,
                        bio = artist.bio,
                        imageUrl = artist.imageUrl
                    })
                    .ToArray();

                return Ok(artists);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet("artists/{id}")]
        public async Task<IActionResult> GetArtistById()
        {
            string id = HttpContext.Request.RouteValues["id"]?.ToString() ?? "";

            try
            {
                if (id == String.Empty)
                    return BadRequest();

                var artist = await db.Artists.FirstOrDefaultAsync(artist => artist.id +"" == id);

                if (artist == null)
                    return NotFound();

                return Ok(artist);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet("albums/{id}")]
        public async Task<IActionResult> GetAlbumsSongs()
        {
            string albumId = HttpContext.Request.RouteValues["id"]?.ToString() ?? "";

            try
            {
                if (albumId == String.Empty)
                    return BadRequest();

                var albumSongs = db.Songs.Where(song => song.albumId + "" == albumId);

                if (albumSongs == null)
                    return BadRequest();

                return Ok(albumSongs);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
