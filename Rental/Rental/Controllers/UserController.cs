using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rental.Data;

namespace Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context )
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetValues ()
        {
            var value = await _context.TBL_USER.ToListAsync();

            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value =await _context.TBL_USER.FirstOrDefaultAsync(x => x.A_ID ==id );

            return Ok(value);
        }
    }
}
