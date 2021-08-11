using AuthorBook.Controllers;
using AuthorBook.domain;
using AuthorBook.repositori;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Collections.Generic;
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
                Id = 10,
                Firstname ="John",
                Lastname="Kurt"
            });
            authorList.Add(new author 
            {
                Id = 11,
                Firstname = "Kurt",
                Lastname = "John"
            });
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);

            //act - handling
            Author1controller classThatIsTested = new Author1controller(dataSource.Object);
            var result = await classThatIsTested.getAuthors();

            //assert - verificer
            var StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, StatusCodeResult.StatusCode);
            
        }
    }
}
