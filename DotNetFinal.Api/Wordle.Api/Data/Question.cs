namespace Wordle.Api.Data
{
    public class Question
    {
        public int Id { get; set; }
        public required string QuestionText { get; set; }
        public required string correctAnswer { get; set; }
        public int QuestionIndex { get; set; }
        public required int QuizId { get; set; }
        public ICollection<Answers> Answers { get; set; } = null!;
    }
}
