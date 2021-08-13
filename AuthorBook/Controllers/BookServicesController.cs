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
    public class BookServicesController : ControllerBase
    {
        private readonly IBookservices _context;
        public BookServicesController(IBookservices BookContext)
        {
            _context = BookContext;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> getBookById2(int id)
        {
            try
            {
                BookDTO book = await _context.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
