using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionsController : ControllerBase
    {
        private readonly DataContext _context;
        public SubmissionsController(DataContext context)
        {
            _context = context;
        }

        
    [HttpGet]
     public async Task<ActionResult<List<submission>>> GetSubmissions() 
    {
        return await _context.Submissions.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<submission>>  GetSubmission(int id) 
    {
        return await _context.Submissions.FindAsync(id);
    }

    }



}