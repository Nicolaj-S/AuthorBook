using AuthorBook.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.services
{
    public interface IBookservices
    {
        Task<BookDTO> GetBookById(int id);
    }
}
