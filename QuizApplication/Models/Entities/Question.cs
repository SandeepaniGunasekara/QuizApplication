namespace QuizApplication.Models.Entities
{
    public record Question
    {
        public Guid Id { get; init; }
        public required string Text { get; init; }
        public required List<Option>Option{ get; set; }
        public required Guid CoorectOption { get; init; }

    }
}
