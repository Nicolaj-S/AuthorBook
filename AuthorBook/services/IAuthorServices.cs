using AuthorBook.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.services
{
    public interface IAuthorServices
    {
        Task<AuthorDTO> GetAuthorById(int id);
    }
}
