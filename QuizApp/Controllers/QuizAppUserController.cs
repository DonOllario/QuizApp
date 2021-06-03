using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizAppUserController : ControllerBase
    {
        private readonly QuizAppDbContext _context;
        public QuizAppUserController(QuizAppDbContext context)
        {
            _context = context;
        }

        //[HttpDelete("DeleteQuizAppUser")]
        //public ActionResult<string> QuizAppUser(string Id)
        //{
        //    var deleteQuizAppUser = User.FindFirstValue(Id);    /*identity.AspNetUsers.Find(Id);*/
        //    if (deleteQuizAppUser == null)
        //    {
        //        return "Couldn't find any QuizAppUser with a corresponding Id, please try again";
        //    }
        //    .Remove(deleteQuizAppUser);
        //    _context.SaveChanges();
        //    return Ok($"The QuizAppUser was deleted succesfully.");
        //}
    }
}
