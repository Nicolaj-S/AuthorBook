using AuthorBook.Controllers;
using AuthorBook.domain;
using AuthorBook.repositori;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthorBook.test
{
    
    public class AuthorRepositoriesTest
    {
        [Fact]    
        public async void getAll_something()
        {
            //tripel a
            //arrange - opsætning
            //objController and mok data
            var dataSource = new Mock<IAuthorRepositori>();
            List<author> authorList = new List<author>();
            authorList.Add(new author
            {
                id = 10,
                firstname ="John",
                lastname="Kurt"
            });
            authorList.Add(new author 
            {
                id = 11,
                firstname = "Kurt",
                lastname = "John"
            });
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);

            //act - handling
            Author1controller classThatIsTested = new Author1controller(dataSource.Object);
            ActionResult<IEnumerable<author>> result = await classThatIsTested.getAuthors();

            //assert - verificer
            var StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, StatusCodeResult.StatusCode);

        }
    }
}
