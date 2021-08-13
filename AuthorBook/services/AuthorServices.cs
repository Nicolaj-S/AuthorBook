using AuthorBook.domain;
using AuthorBook.DTO;
using AuthorBook.repositori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IAuthorRepositori _iauthorRepositori;
        public AuthorServices(IAuthorRepositori authorRepositori)
        {
            _iauthorRepositori = authorRepositori;        
        }
        public async Task<AuthorDTO> GetAuthorById(int id)
        {
            author authors = await _iauthorRepositori.getAuthor(id);
            AuthorDTO dto = new AuthorDTO
            {
                Firstname = authors.Firstname,
                Lastname = authors.Lastname
            };
            return dto;
        }
    }
}
