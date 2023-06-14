namespace Wordle.Api.Data
{
    public class Scores
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int UserId { get; set; }
        public required int QuizId { get; set; }
    }
}
