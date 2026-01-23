using Amplify_backend.Data;
using Amplify_backend.Model;
using Amplify_backend.Services;
using Amplify_backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Amplify_backend.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController: ControllerBase
    {
        private readonly AppDbContext db;
        private readonly JwtService jwt;
        

        public UserController (AppDbContext context, JwtService jwt)
        {
            this.jwt = jwt;
            db = context;
        }

        [HttpPost("login")]
        public async Task<ObjectResult> LoginUser([FromBody] User req)
        {
            try
            {
                User userReq = new User()
                {
                    email = req.email,
                    password = req.password
                };

                var user = await db.Users.FirstOrDefaultAsync(u => u.email == userReq.email);

                bool isPasswordValid = PasswordHasher.VerifyPassword(userReq.password, user?.password ?? "");

                if (!isPasswordValid)
                    return StatusCode(401, "Email or username is incorrect!");

                var token = await jwt.GenerateToken(user!.id);

                var response = new
                {
                    token = token,
                    user = new User
                    {
                        id = user.id,
                        email = user.email,
                        display_name = user.display_name,
                        AvatarUrl = user.AvatarUrl,
                    }
                };

                return StatusCode(200, response);
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
                    display_name = req.display_name,
                    password = hashedPassword,
                    AvatarUrl = req.AvatarUrl,
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
                    user = new User
                    {
                        id = user.id,
                        email = user.email,
                        display_name = user.display_name,
                        AvatarUrl = user.AvatarUrl,
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
        public async Task<ObjectResult> UpdateUserData([FromBody] UserUpdateData req)
        {
            try
            {
                string id = HttpContext.Request.RouteValues["id"]?.ToString() ?? "";

                if (id == "")
                    return StatusCode(500, "Id is not typed");

                var user = await db.Users.FirstOrDefaultAsync(u => u.id + "" == id);

                if (user == null)
                    return StatusCode(404, "User was not found");

                user.display_name = req.display_name ?? user.display_name;
                user.AvatarUrl = req.AvatarUrl ?? user.AvatarUrl;
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
        public async Task<ObjectResult> GetUserData()
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
