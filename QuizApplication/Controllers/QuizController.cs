using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApplication.Data;

namespace QuizApplication.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext dbContext;


        public QuizController(ApplicationDbContext dbContext1) 
        { 
            this.dbContext = dbContext1;

        }


        [HttpGet]
        public IActionResult Index()
        {
            dbContext.Questions.Include(x => x.Option).ToList(); //get the list of all the questions
            return View();
        }
    }
}
