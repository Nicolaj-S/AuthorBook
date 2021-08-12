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
        public Mock<IAuthorRepositori> dataSource = new Mock<IAuthorRepositori>();
        public List<author> authorList = new List<author>();
        Author1controller classThatIsTested;
        IActionResult result;
        public AuthorRepositoriesTest()
        {
            classThatIsTested = new Author1controller(dataSource.Object);
        } 

        [Fact]    
        public async void GetAllReturn200()
        {
            //tripel a
            //arrange - opsætning
            //objController and mok data
            authorList.Add(new author());
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);
            
            //act - handling

            result = await classThatIsTested.getAuthors();

            //assert - verificer
            IStatusCodeActionResult StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, StatusCodeResult.StatusCode);
            
        }
        [Fact]
        public async void GetAllReturn204()
        {
            //tripel a
            //arrange - opsætning
            //objController and mok data
            
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);

            //act - handling
            result = await classThatIsTested.getAuthors();

            //assert - verificer
            IStatusCodeActionResult StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, StatusCodeResult.StatusCode);

        }
        [Fact]
        public void CreateAuthroReturn400()
        {
            IStatusCodeActionResult StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(400, StatusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAllReturn404()
        {
            //tripel a
            //arrange - opsætning
            //objController and mok data

            authorList = null;
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);

            //act - handling
            result = await classThatIsTested.getAuthors();

            //assert - verificer
            IStatusCodeActionResult StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, StatusCodeResult.StatusCode);

        }
    }
}
