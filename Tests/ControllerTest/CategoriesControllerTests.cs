using Data.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuizApp.Controllers.RequestsAndResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.ControllerTest
{
    public class CategoriesControllerTests : TestBase
    {
        public CategoriesControllerTests(TestWebApplicationFactory<TestStartup> factory) : base(factory)
        { }

        [Fact]
        public async Task Should_Return_OK_When_Posting()
        {
            var requestData = new AddCategoryRequest
            {
                Name = "Software",
                Description = "Questions about software development"
            };
            var requestDataAsJson = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(requestDataAsJson, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("api/categories", httpContent);

            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Data_Should_Be_Saved_Correctly_When_Posting()
        {
            var requestData = new AddCategoryRequest
            {
                Name = "Software",
                Description = "Questions about software development"
            };
            var requestDataAsJson = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(requestDataAsJson, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/categories", httpContent);
            var entityInDatabase = await Context.Categories.FirstOrDefaultAsync(x => x.Name == "Software");
            entityInDatabase.Description.Should().Be("Questions about software development");
        }

        [Fact]
        public async Task Should_Return_OK_When_Updating()
        {
            //Arrange

            var category = new Category
            {
                Name = "Software",
                Description = "Questions about software development"
            };

            Context.Categories.Add(category);
            Context.SaveChanges();

            //Act
            var requestData = new UpdateCategoryRequest
            {
                Name = "Software",
                Description = "Questions about software development and hardware"
            };

            var requestDataAsJson = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(requestDataAsJson, Encoding.UTF8, "application/json");
            var response = await Client.PatchAsync($"api/categories/{{category.Id}}", httpContent);

            //Assert
            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        //[Fact]
        //public async Task Data_Should_Be_Saved_Correctly_When_Updating()
        //{
        //    var requestData = new UpdateCategoryRequest
        //    {
        //        Name = "Software",
        //        Description = "Questions about software development and hardware"
        //    };
        //    var requestDataAsJson = JsonConvert.SerializeObject(requestData);
        //    var httpContent = new StringContent(requestDataAsJson, Encoding.UTF8, "application/json");
        //    var response = await Client.PostAsync("api/categories", httpContent);

        //    var entityInDatabase = await Context.Categories.FirstOrDefaultAsync(x => x.Name == "Software");
        //    entityInDatabase.Description.Should().Be("Questions about software development");
        //}
    }
}
