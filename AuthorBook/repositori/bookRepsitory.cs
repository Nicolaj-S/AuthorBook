using AuthorBook.domain;
using AuthorBook.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<book> create(book book)
        {
            book.createdAt = DateTime.UtcNow;
            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<ActionResult<book>> delete(int id)
        {
            book book = await _context.books.FindAsync(id);
            if (book != null)
            {
                _context.books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return book == null ? new NotFoundResult() : new OkResult();

        }

        public async Task<book> getAuthorsBook(int bookId)
        {
            return await _context.books.FindAsync(bookId);
        }

        public async Task<book> getBook(int id)
        {
            book book = await _context.books.FindAsync(id);
            return book;
        }

        public async Task<List<book>> getBooks()
        {
            List<book> book = await _context.books.ToListAsync();
            return book;
        }

        public async Task<ActionResult<book>> update(book book)
        {
            book updateBook = await _context.books.FindAsync(book.id);
            if (updateBook != null)
            {
                updateBook.title = book.title;
                updateBook.pages = book.pages;
                updateBook.authorid = book.authorid;
                updateBook.updatedAt = DateTime.UtcNow;
                _context.books.Update(updateBook);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
    }
}
