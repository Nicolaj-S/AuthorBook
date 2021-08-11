using AuthorBook.domain;
using AuthorBook.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorBook.repositori
{
    public class authorRepositori : IAuthorRepositori
    {
        private readonly DatabaseContext _context;

        public authorRepositori(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<author> create(author author)
        {
            author.CreatedAt = DateTime.UtcNow;
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
            //laver en author    
        }

        public async Task<ActionResult<author>> delete(int id)
        {
            author author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
            return author == null ? new NotFoundResult(): new OkResult();
        }
        public async Task<ActionResult<author>> update( author author)
        {
            author updateAuthor = await _context.Authors.FindAsync(author.Id);
            if (updateAuthor != null)
            {
                updateAuthor.Firstname = author.Firstname; 
                updateAuthor.Lastname = author.Lastname;
                updateAuthor.UpdatedAt = DateTime.UtcNow;
                _context.Authors.Update(updateAuthor);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
        public async Task<author> getAuthor(int id)
        {
            author author = await _context.Authors.FindAsync(id);
            return author;
        }
        public async Task<List<author>> getAuthors()
        {
            List<author> authors = await _context.Authors.ToListAsync();
            return authors;
        }
        /*public async Task<List<author>> getAuthors(int start, int limit)
        {
            List<author> authors = await _context.authors.ToListAsync();
            return authors;
        }*/
        public async Task<author> getAuthorBooks(int authorId)
        {
            return await _context.Authors.FindAsync(authorId);    
        }
    }
}
