using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Common.Entities
{
   public class Score
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10), Required]
        public int Number { get; set; }

        public int QuizAppUserId { get; set; }

        public QuizAppUser QuizAppUser { get; set; }

        public Category Category { get; set; }

        public List<Category> Categories { get; set; }

    }
}

