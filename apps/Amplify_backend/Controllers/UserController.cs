using Amplify_backend.Data;
using Amplify_backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace Amplify_backend.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController: ControllerBase
    {
        private readonly AppDbContext db;

        public UserController (AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = db.Users.ToList();
            return Ok(users);
        }

        [HttpPost ("create")]
        public async Task<ObjectResult> CreateUser([FromBody] User req)
        {
            try
            {
                var result = await db.Users.AddAsync(new Model.User
                {
                    Email = req.Email,
                    Username = req.Username,
                    HashedPassword = req.HashedPassword
                });

                await db.SaveChangesAsync();

                if (!result.IsKeySet)
                    return StatusCode(500, "User created unsuccesfully");

                Console.Write(result);

                return StatusCode(201, "User created successfully.");
            }
            catch
            {
                return StatusCode(500, "An error occurred while creating the user.");
            }
        }
    }
}
