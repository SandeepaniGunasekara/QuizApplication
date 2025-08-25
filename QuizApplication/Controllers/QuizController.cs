using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuizApplication.Data;
using QuizApplication.Models.ViewModels;

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
            var questions = dbContext.Questions.Include(x => x.Options)
                .Select(x=>new QuestionItem()
                {

                    Id = x.Id,
                    Text = x.Text,
                    Options = x.Options.Select(y => new SelectListItem(y.Text, y.Id.ToString())).ToList()
                })
             .ToList(); //get the list of all the questions



            return View(new QuizViewModel() { Questions = questions });
        }

        [HttpPost]
        public IActionResult Submit(List<Guid> userANswers)
        {
            var questions = dbContext.Questions.ToList();
            var score = 0;
            var totalScore = questions.Count;
            for (var i = 0; i < userANswers.Count; i++) 
            {
                if (questions[i].CoorectOption == userANswers[i])
                {
                    score++;
                }
            }



            ViewBag.Score = score;
            ViewBag.TotalScore = totalScore;
            return View("Results");
        }
    }
}
