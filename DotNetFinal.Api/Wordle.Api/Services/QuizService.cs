using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services;

public class QuizService
{
    private readonly AppDbContext _db;
    private static readonly object _WordOfTheDayLock = new object();

    public QuizService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Quiz>> GetQuizList()
    {
        IQueryable<Quiz> query = _db.Quiz;

        var count = await query.CountAsync();
        // return the last full page
        var list = await query
          .OrderBy(w => w.Name)
          .ToListAsync();

        return list;
    }

    public async Task<IEnumerable<Question>> GetQuestionList()
    {
        IQueryable<Question> query = _db.Questions;

        var count = await query.CountAsync();
        // return the last full page
        var list = await query
          .OrderBy(w => w.QuizId)
          .ToListAsync();

        return list;
    }

    public async Task<IEnumerable<Question>> GetQuestions(int id)
    {
        IQueryable<Question> query = _db.Questions;

        var count = await query.CountAsync();
        // return the last full page
        var list = await query
          .Where(w => w.QuizId == id)
          .OrderBy(w => w.QuizId)
          .ToListAsync();

        return list;
    }

    public async Task<IEnumerable<Answers>> GetAnswerList()
    {
        IQueryable<Answers> query = _db.Answers;

        var count = await query.CountAsync();
        // return the last full page
        var list = await query
          .OrderBy(w => w.Id)
          .ToListAsync();

        return list;
    }

    public async Task<IEnumerable<Answers>> GetAnswers(int Id)
    {
        IQueryable<Answers> query = _db.Answers;

        var count = await query.CountAsync();
        // return the last full page
        var list = await query
          .Where (w => w.QuestionId == Id)
          .OrderBy(w => w.Id)
          .ToListAsync();

        return list;
    }

    public async Task<IEnumerable<Scores>> GetScores(int Id)
    {
        IQueryable<Scores> query = _db.Scores;

        var count = await query.CountAsync();
        // return the last full page
        var list = await query
          .Where(w => w.QuizId == Id)
          .OrderBy(w => w.Id)
          .ToListAsync();

        return list;
    }
    public async Task<Quiz> AddQuiz(string? quizName)
    {
        if (quizName is null)
        {
            throw new ArgumentException("Quiz name can not be null");
        }
        var quiz = await _db.Quiz.FirstOrDefaultAsync(w => w.Name == quizName);
        if (quiz != null)
        {
            throw new ArgumentException("Quiz name can not be null");

        }
        else
        {
            quiz = new() { Name = quizName };
            _db.Quiz.Add(quiz);
        }
        await _db.SaveChangesAsync();
        return quiz;

    }

    public async Task<Question> AddQuestion(string? questionText, int quizId, string? correctAnswer)
    {
        if (questionText is null || correctAnswer is null)
        {
            throw new ArgumentException("Quiz name can not be null");
        }
        var question = await _db.Questions.FirstOrDefaultAsync(w => w.QuestionText == questionText);
        var quiz = await _db.Quiz.FirstOrDefaultAsync(w => w.Id == quizId);
        if (question != null && question.QuizId == quizId)
        {
            throw new ArgumentException("Question already exists in quiz");
        }
        if (quiz is null)
        {
            throw new ArgumentException("Quiz Does not exist");

        }
        else
        {

            question = new() { 
                correctAnswer = correctAnswer,
                QuestionText = questionText,
                QuizId = quizId
            };
            _db.Questions.Add(question);
            quiz.Questions.Add(question);
        }
        await _db.SaveChangesAsync();
        return question;

    }

    public async Task<Answers> AddAnswer(string? AnswerText, int questionId = 0)
    {
        if (AnswerText is null)
        {
            throw new ArgumentException("Quiz name can not be null");
        }
        var answer = await _db.Answers.FirstOrDefaultAsync(w => w.Answer == AnswerText);
        var question = await _db.Questions.FirstOrDefaultAsync(w => w.Id == questionId);
        if (answer != null && question != null) 
        {
            throw new ArgumentException("Quiz name can not be null");
        }
        else
        {

            answer = new()
            {
                Answer = AnswerText,
                QuestionId = questionId
            };
            _db.Answers.Add(answer);
        }
        await _db.SaveChangesAsync();
        return answer;

    }

    public async Task<Scores> AddScore(int score = 0, int quizId = 1)
    {
         

        var answer = new Scores()
        {
             Score = score,
             QuizId = quizId
        };
        _db.Scores.Add(answer);
        await _db.SaveChangesAsync();
        return answer;

    }

}
