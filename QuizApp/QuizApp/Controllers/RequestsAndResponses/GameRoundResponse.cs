using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers.RequestsAndResponses
{
    public class GameRoundResponse
    {
        public Guid Id { get; set; }
        public int NumberOfQuestions { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime? TimeEnded { get; set; }
        //dont think this is needed:
        //public ICollection<Guid> QuestionStatisticIds { get; set; }
    }
}
