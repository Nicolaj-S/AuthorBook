using AuthorBook.domain;
using AuthorBook.repositori;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //endpoint
    public class Author1controller : ControllerBase
    {
        public Author1controller(IAuthorRepositori authorRep)
        {
            _context = authorRep;
        }
        public IAuthorRepositori _context { get; set; }
        //methoder der kalder på database

        [HttpGet]
        public async Task<IActionResult> getAuthors()
        {
            try
            {
                var Authors = await _context.getAuthors();
                return Authors == null ? NoContent() : Ok(Authors);
            }
            /*if (Author == null) { return NoContent(); } return await _authorRep.create(Author);*/
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<author>> getAuthor(int id)
        {
            try
            {
                author author = await _context.getAuthor(id);
                return author == null ? NotFound() : Ok(author);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpGet("authorAndBooks")]
        public async Task<ActionResult<author>> getAuthorBooks(int authorId)
        {
            author author = await _context.getAuthorBooks(authorId);
            return author == null ? NotFound() : Ok(author);
        }
        [HttpPatch("Update")]
        public async Task<ActionResult<author>> update(author author)
        {
            return await _context.update(author);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<author>> delete(int id)
        {
            return await _context.delete(id);
        }
        [HttpPost]
        public async Task<ActionResult<author>> PostAuthor(author Author)
        {
            try 
            { 
                return Author == null ? NoContent() : await _context.create(Author);  
            }
            /*if (Author == null) { return NoContent(); } return await _authorRep.create(Author);*/
            catch (Exception e) 
            { 
                return Problem(e.Message); 
            }
        }
        //public string get() { return "Endpoint"; }
    }
}
