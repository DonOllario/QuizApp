using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOModels
{
   public class ScoreDTO
    {
        public int ScoreId { get; set; }

        public int ScoreNumber { get; set; }

        public int QuizAppUserId { get; set; }

        public QuizAppUser QuizAppUser { get; set; }

        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

    }
}
