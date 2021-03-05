using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questionary.Database.Context;
using Questionary.Database.Entity;
using Questionary.Database.Entity.Enum;

namespace Questionary.Api.Services
{
    public interface IQuizService
    {
        Task<object> GetAsync(int id);
        Task<object> AddAsync(string name, QuestionGroup @group);
        Task<int> UpdateAsync(int id);
    }

    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _context;

        public QuizService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetAsync(int id)
        {
            var quiz = await _context.QuizModels.Include(x=>x.UserModel).FirstOrDefaultAsync(x => x.Id == id);
            if (quiz == null)
                return 404;

            // get all quiz answers and group them by question id
            var quizAnswers = (await _context.QuizAnswerModels.Where(x => x.QuizId == quiz.Id)
                    .Select(x => new
                    {
                        x.QuestionChoiceModel.QuestionId,
                        x.QuestionChoiceModel.Id,
                    }).ToListAsync()).GroupBy(x => x.QuestionId)
                .Select(x => new
                {
                    Question = x.Key,
                    Answers = string.Join(",", x.Select(c => c.Id).OrderBy(c => c).ToList())
                }).ToList();

                // get all question answers and group them by question id
                var questionAnswers = (await _context.QuestionChoiceModels
                    .Where(x => x.QuestionModel.Group == quiz.QuestionGroup && x.IsAnswer)
                    .Select(x => new
                    {
                        x.QuestionId,
                        x.Id
                    }).ToListAsync()).GroupBy(x => x.QuestionId)
                .Select(x => new
                {
                    Question = x.Key,
                    Answers = string.Join(",", x.Select(c => c.Id).OrderBy(c => c).ToList())
                }).ToList();

            // check the correct answers
            var result = (from questionAnswer in questionAnswers
                join quizAnswer in quizAnswers on questionAnswer.Question equals quizAnswer.Question
                select new
                {
                    questionAnswer.Question,
                    IsCorrect = questionAnswer.Answers == quizAnswer.Answers
                }).ToList();

            return new
            {
                quiz.DateStarted,
                quiz.DateEnded,
                quiz.UserModel.Name,
                result
            };
        }

        public async Task<object> AddAsync(string name, QuestionGroup @group)
        {
            var user =
                await _context.UserModels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.Trim().ToLower()) ??
                new UserModel()
                {
                    Name = name
                };

            var quiz = new QuizModel()
            {
                DateStarted = DateTimeOffset.Now,
                UserModel = user,
                QuestionGroup = @group,
            };
            await _context.QuizModels.AddAsync(quiz);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
                return 400;

            return new { QuizId = quiz.Id, UserName = user.Name };
        }

        public async Task<int> UpdateAsync(int id)
        {
            var quiz = await _context.QuizModels.FirstOrDefaultAsync(x =>x.Id == id);
            if (quiz == null)
                return 404;

            quiz.DateEnded = DateTimeOffset.Now;
            _context.QuizModels.Update(quiz);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
                return 400;

            return 200;
        }
    }
}
