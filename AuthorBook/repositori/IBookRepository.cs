using AuthorBook.domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorBook.repositori
{
    public interface IBookrepository
    {
        Task<ActionResult<book>> create(book book);
        Task<ActionResult<book>> delete(int id);
        Task<ActionResult<book>> update(book book);
        Task<List<book>> getBooks();
        Task<book> getBook(int id);
        Task<book> getAuthorsBook(int bookId);

    }
}
