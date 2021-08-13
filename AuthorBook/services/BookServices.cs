using AuthorBook.domain;
using AuthorBook.DTO;
using AuthorBook.repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.services
{
    public class BookServices : IBookservices
    {
        private readonly IBookrepository _iBookRepository;
        public BookServices(IBookrepository BookRepositori)
        {
            _iBookRepository = BookRepositori;
        }
        public async Task<BookDTO> GetBookById(int id)
        {
            book books = await _iBookRepository.getBook(id);
            BookDTO dto = new BookDTO
            {
                title = books.Title,
                pages = books.Pages,
                published = books.Published
            };
            return dto;
        }
    }
}
