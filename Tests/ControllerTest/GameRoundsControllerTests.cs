using Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using QuizApp.Controllers.RequestsAndResponses;

namespace Tests.ControllerTest
{
    public class GameRoundsControllerTests : TestBase
    {
        public GameRoundsControllerTests(TestWebApplicationFactory<TestStartup> factory) : base(factory)
        { }

        [Fact]
        public async Task Should_Return_OK_When_Starting_New_Gameround()
        {
            var startGameRound = new AddGameRoundRequest
            {
                NumberOfQuestions = 10
            };
            var requestDataAsJson = JsonConvert.SerializeObject(startGameRound);
            var httpContent = new StringContent(requestDataAsJson, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("gameround", httpContent);

            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Should_Return_OK_When_Deleting_GameRound()
        {
            var AddGame = new GameRoundResponse
            {
                GameRoundId = new Guid(),
                NumberOfQuestions = 10,
                TimeStarted = DateTime.Now
            };
        }
    }
}
