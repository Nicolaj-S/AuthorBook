using AuthorBook.domain;
using AuthorBook.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorBook.repositori
{
    public class bookRepsitory : IBookrepository
    {
        private readonly DatabaseContext _context;

        public bookRepsitory(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<book>> create(book book)
        {
            book.CreatedAt = DateTime.UtcNow;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book == null ? new NotFoundResult() : new OkResult();
        }

        public async Task<ActionResult<book>> delete(int id)
        {
            book book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return book == null ? new NotFoundResult() : new OkResult();

        }

        public async Task<book> getAuthorsBook(int bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public async Task<book> getBook(int id)
        {
            book book = await _context.Books.FindAsync(id);
            return book;
        }

        public async Task<List<book>> getBooks()
        {
            List<book> book = await _context.Books.ToListAsync();
            return book;
        }

        public async Task<ActionResult<book>> update(book book)
        {
            book updateBook = await _context.Books.FindAsync(book.Id);
            if (updateBook != null)
            {
                updateBook.Title = book.Title;
                updateBook.Pages = book.Pages;
                updateBook.Authorid = book.Authorid;
                updateBook.UpdatedAt = DateTime.UtcNow;
                _context.Books.Update(updateBook);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
    }
}
