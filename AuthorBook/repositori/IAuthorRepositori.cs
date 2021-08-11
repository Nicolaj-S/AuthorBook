using AuthorBook.domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorBook.repositori
{
    public interface IAuthorRepositori
    {
        Task<author> create(author author);
        Task<ActionResult<author>> delete(int id);
        Task<ActionResult<author>> update(author author);
        Task<List<author>> getAuthors();
        //Task<List<author>> getAuthors(int start, int limit);
        Task<author> getAuthor(int id);
        Task<author> getAuthorBooks(int authorId);


    }
}
