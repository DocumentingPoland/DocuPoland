using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;

        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetUsers() 
        {
            return await _context.AppUsers.ToListAsync();

        }
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>  GetUser(int id) 
        {
            return await _context.AppUsers.FindAsync(id);
        }

    }
}