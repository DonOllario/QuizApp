using System;

namespace Data.Models
{
    public class QuestionStatistic
    {
        public Guid Id { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime? TimeEnded { get; set; }
        public bool AnsweredCorrectly { get; set; }
    }
}
