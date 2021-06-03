using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class GameRound
    {
        public GameRound()
        {
            QuestionStatistics = new List<QuestionStatistic>();
        }
        public Guid GameRoundId { get; set; }
        public int NumberOfQuestions { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime? TimeEnded { get; set; }

        public Guid QuestionStatisticId { get; set; }
        public ICollection<QuestionStatistic> QuestionStatistics { get; set; }
        //public User User { get; set; }
        //public ICollection<Question> Questions { get; set; }
    }
}
