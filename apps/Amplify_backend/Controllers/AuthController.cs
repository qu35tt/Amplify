using Amplify_backend.Data;
using Amplify_backend.Model;
using Amplify_backend.Services;
using Amplify_backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amplify_backend.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController: ControllerBase
    {
        private readonly AppDbContext db;
        private readonly JwtService jwt;
        

        public AuthController (AppDbContext context, JwtService jwt)
        {
            this.jwt = jwt;
            db = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] Users req)
        {
            try
            {
                Users userReq = new Users()
                {
                    email = req.email,
                    password = req.password
                };

                var user = await db.Users.FirstOrDefaultAsync(u => u.email == userReq.email);

                bool isPasswordValid = PasswordHasher.VerifyPassword(userReq.password, user?.password ?? "");

                if (!isPasswordValid)
                    return Unauthorized("Email or username is incorrect!");

                var token = await jwt.GenerateToken(user!.id);

                var response = new
                {
                    token = token,
                    user = new Users
                    {
                        id = user.id,
                        email = user.email,
                        displayName = user.displayName,
                        avatarUrl = user.avatarUrl,
                    }
                };

                return Ok(response);
            }
            catch
            {
                return StatusCode(500, "Server error");
            }

        }

        [HttpPost ("create")]
        public async Task<IActionResult> CreateUser([FromBody] Users req)
        {
            try
            {
                // Hash the password before storing it
                var hashedPassword = PasswordHasher.HashPassword(req.password);

                bool userExists = await db.Users.AnyAsync(u => u.email == req.email);

                if (userExists)
                    return BadRequest("User already registered!");

                var result = await db.Users.AddAsync(new Users
                {
                    email = req.email,
                    displayName = req.displayName,
                    password = hashedPassword,
                    avatarUrl = req.avatarUrl,
                    isAdmin = false,
                });

                await db.SaveChangesAsync();

                if (!result.IsKeySet)
                    return StatusCode(500, "User created unsuccesfully");

                var user = result.Entity;

                var token = await jwt.GenerateToken(user.id);

                var response = new
                {
                    token = token,
                    user = new Users
                    {
                        id = user.id,
                        email = user.email,
                        displayName = user.displayName,
                        avatarUrl = user.avatarUrl,
                    }
                };

                return StatusCode(201, response);
            }
            catch
            {
                return StatusCode(500, "An error occurred while creating the user.");
            }
        }

        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUserData([FromBody] UserUpdateData req)
        {
            try
            {
                string id = HttpContext.Request.RouteValues["id"]?.ToString() ?? "";

                if (id == "")
                    return StatusCode(500, "Id is not typed");

                var user = await db.Users.FirstOrDefaultAsync(u => u.id + "" == id);

                if (user == null)
                    return StatusCode(404, "User was not found");

                user.displayName = req.display_name ?? user.displayName;
                user.avatarUrl = req.AvatarUrl ?? user.avatarUrl;
                user.email = req.email ?? user.email;
                user.updatedAt = DateTime.UtcNow;

                if (!string.IsNullOrWhiteSpace(req.password))
                    user.password = PasswordHasher.HashPassword(req.password);
                

                await db.SaveChangesAsync();

                return StatusCode(200, "User Updated Succesfully");
            }
            catch
            {
                return StatusCode(500, "Server error");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserData()
        {
            try
            {
                string id = HttpContext.Request.RouteValues["id"]?.ToString() ?? "";

                if (id == "")
                    return StatusCode(500, "Id is not typed");

                var result = await db.Users.FirstOrDefaultAsync(u => u.id.ToString() == id);


                if (result?.id == Guid.Empty)
                    return StatusCode(404, "User not found");

                return StatusCode(200, result);
            }
            catch
            {
                return StatusCode(500, "An error occured while finding a person");
            }
        }
    }
}
