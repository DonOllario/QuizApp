using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers.RequestsAndResponses
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
