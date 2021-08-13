using AuthorBook.DTO;
using AuthorBook.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authorServicesController : ControllerBase
    {
        private readonly IAuthorServices _context;
        public authorServicesController(IAuthorServices authorContext)
        {
            _context = authorContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> getAuthorById2(int id)
        {
            try
            {
                AuthorDTO author = await _context.GetAuthorById(id);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(author);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
