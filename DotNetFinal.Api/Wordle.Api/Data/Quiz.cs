namespace Wordle.Api.Data
{
    public class Quiz
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int QuestionCount { get; set; }
        public ICollection<Question> Questions { get; set; } = null!;
        public ICollection<Scores> Games { get; set; } = null!;

    }
}
