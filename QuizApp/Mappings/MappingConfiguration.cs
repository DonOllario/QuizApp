using AutoMapper;
using Data.Models;
using QuizApp.Controllers.RequestsAndResponses;
using System;


namespace QuizApp.Mappings
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AddGameRoundRequest, GameRound>()
                .AfterMap((from, to) => to.TimeStarted = DateTime.Now);
        }
    }
}
