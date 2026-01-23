using Amplify_backend.Data;
using Amplify_backend.Model;
using Amplify_backend.Services;
using Amplify_backend.Utils;
using Microsoft.AspNetCore.Authorization;
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
                    user = new
                    {
                        id = user.id,
                        email = user.email,
                        username = user.username
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
                    username = req.username,
                    password = hashedPassword
                });

                await db.SaveChangesAsync();

                if (!result.IsKeySet)
                    return StatusCode(500, "User created unsuccesfully");

                var user = result.Entity;

                var token = await jwt.GenerateToken(user.id);

                var response = new
                {
                    token = token,
                    user = new
                    {
                        id = user.id,
                        email = user.email,
                        username = user.username
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
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetUserData()
        {
            try
            {
                string id = HttpContext.Request.RouteValues["id"]?.ToString() ?? "";

                if (id == "")
                    return StatusCode(500, "Id is not typed");

                var result = await db.Users.FirstOrDefaultAsync(u => u.id.ToString() == id);


                if (result?.id < 1)
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
