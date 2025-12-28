namespace signuppage.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using signuppage.Data;

    using System.Security.Cryptography;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Signup successful");
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
