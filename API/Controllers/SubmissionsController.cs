using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class SubmissionsController : BaseApiController
    {
        private readonly DataContext _context;
        public SubmissionsController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Submission>>> GetSubmissions() 
        {
            return await _context.Submissions.ToListAsync();

        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Submission>>  GetSubmission(int id) 
        {
            return await _context.Submissions.FindAsync(id);
        }

    }



}