using System;

namespace Data.Models
{
    public class QuestionStatistic
    {
        public Guid QuestionStatisticId { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime? TimeEnded { get; set; }
        public bool AnsweredCorrectly { get; set; }

        public Guid GameRoundId { get; set; }
        public GameRound GameRound { get; set; }
    }
}
