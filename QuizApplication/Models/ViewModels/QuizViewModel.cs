using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuizApplication.Models.ViewModels
{
    public class QuizViewModel
    {
        public required List<QuestionItems> Questions { get; set; } = [];
    }

    public class QuestionItems
    {
        public required Guid Id { get; set; }
        public required string Text { get; set; }
        public required List<SelectListItem> Options { get; set; }
    }
}
