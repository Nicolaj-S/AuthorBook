using AuthorBook.Controllers;
using AuthorBook.domain;
using AuthorBook.repositori;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace AuthorBook.test
{

    public class AuthorRepositoriesTest
    {
        [Fact]    
        public async void GetAuthor_Return200()
        {
            //tripel a
            //arrange - opsætning
            //objController and mok data
            Mock<IAuthorRepositori> dataSource = new Mock<IAuthorRepositori>();
            List<author> authorList = new List<author>();
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);

            //act - handling
            Author1controller classThatIsTested = new Author1controller(dataSource.Object);
            IActionResult result = await classThatIsTested.getAuthors();

            //assert - verificer
            IStatusCodeActionResult StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, StatusCodeResult.StatusCode);
            
        }
    }
}
