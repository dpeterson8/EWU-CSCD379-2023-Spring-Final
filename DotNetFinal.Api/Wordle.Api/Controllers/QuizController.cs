using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Identity;
using Wordle.Api.Models;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly QuizService _quizService;
        public QuizController(QuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("GetQuizList")]
        public async Task<IEnumerable<Quiz>> GetQuizList()
        {
            return await _quizService.GetQuizList();
        }

        [HttpGet("GetQuestionList")]
        public async Task<IEnumerable<Question>> GetQuestionList()
        {
            return await _quizService.GetQuestionList();
        }

        [HttpGet("GetQuestions")]
        public async Task<IEnumerable<Question>> GetQuestions(int Id)
        {
            return await _quizService.GetQuestions(Id);
        }

        [HttpGet("GetAnswerList")]
        public async Task<IEnumerable<Answers>> GetAnswerList()
        {
            return await _quizService.GetAnswerList();
        }

        [HttpGet("GetAnswers")]
        public async Task<IEnumerable<Answers>> GetAnswers(int Id)
        {
            return await _quizService.GetAnswers(Id);
        }

        [HttpGet("GetScores")]
        public async Task<IEnumerable<Scores>> GetScores(int Id)
        {
            return await _quizService.GetScores(Id);
        }

        [HttpPost]
        public async Task<Quiz> CreateNewQuiz(string? name = "newQuiz")
        {
            return await _quizService.AddQuiz(name);
        }

        [HttpPost("Question")]
        public async Task<Question> CreateNewQuestion(int quizId = 0, string? name = "newQuiz", string? correctAnswer = "")
        {
            return await _quizService.AddQuestion(name, quizId, correctAnswer);
        }

        [HttpPost("Answer")]
        public async Task<Answers> AddAnswers(string? AnswerText, int questionId = 0)
        {
            return await _quizService.AddAnswer(AnswerText, questionId);
        }

        [HttpPost("Scores")]
        public async Task<Scores> AddScoress(int score = 0, int quizId = 1)
        {
            return await _quizService.AddScore(score, quizId);
        }

    }
}
