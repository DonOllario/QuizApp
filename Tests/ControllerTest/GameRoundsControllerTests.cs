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
using Data.Models;

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

            var response = await Client.PostAsync("api/gamerounds", httpContent);

            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Should_Return_OK_When_Deleting_GameRound()
        {
            var addGame = new GameRound
            {
                NumberOfQuestions = 10,
                TimeStarted = DateTime.Now
            };


            Context.GameRounds.Add(addGame);
            Context.SaveChanges();

            
            var response = await Client.DeleteAsync($"api/gamerounds/{addGame.GameRoundId}");


            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.NoContent);

        }
    }
}
