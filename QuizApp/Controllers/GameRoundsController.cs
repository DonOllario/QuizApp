﻿using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Controllers.RequestsAndResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameRoundsController : ControllerBase
    {
        private readonly QuizAppDbContext _context;
        public GameRoundsController(QuizAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("id:Guid", Name = "GetGameRound")]
        public async Task<ActionResult<GameRoundResponse>> GetGameRound(Guid id)
        {
            var gameRoundFromDb = await _context.GameRounds.FindAsync(id);
            var response = new GameRoundResponse
            {
                GameRoundId = gameRoundFromDb.GameRoundId,
                NumberOfQuestions = gameRoundFromDb.NumberOfQuestions,
                TimeEnded = gameRoundFromDb.TimeEnded,
                TimeStarted = gameRoundFromDb.TimeStarted
            };
            return Ok(response);
        }

        //[HttpGet]
        //public async Task<ActionResult<GameRoundResponse>> GetGameRounds(GameRound round)
        //{
        //    var gameRounds = await _context.FindAsync<GameRound>();

        //    var gameRoundFromDb =  await _context.GameRounds.FindAsync(round);
        //    var gameRoundResponses = new List<GameRoundResponse>();

        //    foreach (var gameRound in gameRoundFromDb)
        //    {
        //        var gameRoundResponse = new GameRoundResponse
        //        {
        //            Id = gameRoundFromDb.Id,
        //            NumberOfQuestions = gameRoundFromDb.NumberOfQuestions,
        //            TimeEnded = gameRoundFromDb.TimeEnded,
        //            TimeStarted = gameRoundFromDb.TimeStarted
        //        };
        //        gameRoundResponses.Add(gameRound);

        //        return Ok(gameRounds);
        //}

        [HttpPost]
        public async Task<ActionResult<GameRoundResponse>> AddGameRound([FromBody] AddGameRoundRequest request)
        {
            var gameRound = new GameRound
            {
                NumberOfQuestions = request.NumberOfQuestions
            };
            _context.GameRounds.Add(gameRound);
            await _context.SaveChangesAsync();

            var response = new GameRoundResponse
            {
                GameRoundId = gameRound.GameRoundId,
                NumberOfQuestions = gameRound.NumberOfQuestions,
                TimeEnded = gameRound.TimeEnded,
                TimeStarted = gameRound.TimeStarted
            };

            return CreatedAtRoute("GetGameRound", new { id = response.GameRoundId }, response);
        }

        [HttpDelete("DeleteGameRound")]
        public ActionResult<string> DeleteCustomer(Guid gameRoundId)
        {
            var deleteGameRound = _context.GameRounds.Find(gameRoundId);
            if (deleteGameRound == null)
            {
                return "Couldn't find any GameRound with a corresponding Id, please try again";
            }
            _context.GameRounds.Remove(deleteGameRound);
            _context.SaveChanges();
            return Ok($"The GameRound was deleted succesfully.");
        }

    }
}
