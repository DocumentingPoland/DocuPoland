using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;

        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDTO) 
        {
            // check if email exists
            if (await EmailExists(registerDTO.Email)) return BadRequest("Email aready registered");

            using var hmac = new HMACSHA512();

            // create user
            var user = new AppUser() 
            {
                Email = registerDTO.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key
            };

            // track changes
            _context.AppUsers.Add(user);
            // save to db
            await _context.SaveChangesAsync();
            return user;
            
        }

        // email exsist method
        private async Task<bool> EmailExists(string email) 
        {
            return await _context.AppUsers.AnyAsync(x => x.Email == email.ToLower());
        }


        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDTO loginDTO) 
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.Email == loginDTO.Email.ToLower());

            if (user == null) 
            {
                return Unauthorized("Invalid");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < computedHash.Length; i++) 
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid p");

            }

            return user;



        }

    }
}