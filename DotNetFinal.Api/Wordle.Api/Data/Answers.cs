namespace Wordle.Api.Data
{
    public class Answers
    {
        public int Id { get; set; }
        public required string Answer { get; set; }
        public required int QuestionId { get; set; }

    }
}
