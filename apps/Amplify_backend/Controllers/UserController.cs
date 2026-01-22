using Amplify_backend.Data;
using Amplify_backend.Model;
using Amplify_backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost("login")]
        public async Task<ObjectResult> LoginUser([FromBody] User req)
        {
            try
            {
                User user = new User()
                {
                    email = req.email,
                    password = req.password
                };

                var result = await db.Users.FirstOrDefaultAsync(u => u.email == user.email);

                return StatusCode(200, result?.id);
            }
            catch
            {
                return StatusCode(500, "Server error");
            }

        }

        [HttpPost ("create")]
        public async Task<ObjectResult> CreateUser([FromBody] User req)
        {
            try
            {
                // Hash the password before storing it
                var hashedPassword = PasswordHasher.HashPassword(req.password);

                bool userExists = await db.Users.AnyAsync(u => u.email == req.email);

                if (userExists)
                    return StatusCode(400, "User already registered!");

                var result = await db.Users.AddAsync(new User
                {
                    email = req.email,
                    username = req.username,
                    password = hashedPassword
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
