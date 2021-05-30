using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Common.Entities
{
  public class UserScore
    {
        public int UserId { get; set; }
        public QuizAppUser User { get; set; }

        public Score Score { get; set; }
        public int ScoreId { get; set; } 
    }
}
