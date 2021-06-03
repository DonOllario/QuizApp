using Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Xunit;

namespace Tests
{
    public class TestBase : IClassFixture<TestWebApplicationFactory<TestStartup>>
    {
        protected readonly HttpClient Client;
        private readonly TestWebApplicationFactory<TestStartup> _factory;
        protected readonly QuizAppDbContext Context;
        public TestBase(TestWebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
            Client = _factory.CreateClient();
            Context = _factory.Server.Services.GetService(typeof(QuizAppDbContext)) as QuizAppDbContext;
            Context.Database.EnsureCreated();
        }
    }
}
