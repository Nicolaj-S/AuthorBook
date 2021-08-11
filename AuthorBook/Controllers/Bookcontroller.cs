using AuthorBook.domain;
using AuthorBook.repositori;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AuthorBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bookcontroller : ControllerBase
    {
        public Bookcontroller(IBookrepository BookRep)
        {
            _context = BookRep;
        }
        public IBookrepository _context { get; set; }
        //methoder der kalder på database

        [HttpGet]
        public async Task<ActionResult<IEnumerable<book>>> getBooks()
        {
            try
            {
                var books = await _context.getBooks();
                return books == null ? NoContent() : await _context.getBooks();
            }
            /*if (Author == null) { return NoContent(); } return await _authorRep.create(Author);*/
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<book>> getBook(int id)
        {
            try
            {
                book book = await _context.getBook(id);
                return book == null ? NotFound() : Ok(book);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpGet("authorAndBooks")]
        public async Task<ActionResult<book>> getAuthorsBook(int bookId)
        {
            book book = await _context.getAuthorsBook(bookId);
            return book == null ? NotFound() : Ok(book);
        }
        [HttpPatch("Update")]
        public async Task<ActionResult<book>> update(book book)
        {
            return await _context.update(book);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<book>> delete(int id)
        {
            return await _context.delete(id);
        }
        [HttpPost]
        public async Task<ActionResult<book>> PostAuthor(book book)
        {
            try
            {
                return book == null ? NoContent() : await _context.create(book);
            }
            /*if (Author == null) { return NoContent(); } return await _authorRep.create(Author);*/
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
