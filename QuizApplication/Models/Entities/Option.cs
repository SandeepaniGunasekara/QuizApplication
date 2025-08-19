namespace QuizApplication.Models.Entities
{
    public class Option
    {
        public Guid Id { get; init; }
        public required string Text { get; init; }

        //to define the relationship between question no and the option
        public Guid QuestionId { get; init; }

    }
}
