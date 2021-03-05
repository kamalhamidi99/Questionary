using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questionary.Database.Context;
using Questionary.Database.Entity;

namespace Questionary.Api.Services
{
    public interface IQuizAnswerService
    {
        Task<int> AddAsync(int quizId, string answerIds);
    }

    public class QuizAnswerService : IQuizAnswerService
    {
        private readonly ApplicationDbContext _context;

        public QuizAnswerService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(int quizId, string answerIds)
        {
            var quiz = await _context.QuizModels.FirstOrDefaultAsync(x => x.Id == quizId);
            if (quiz == null)
                return 404;

            if (string.IsNullOrWhiteSpace(answerIds))
                return 400;

            foreach (var answerId in answerIds.Split(",").ToList())
            {
                await _context.QuizAnswerModels.AddAsync(new QuizAnswerModel()
                {
                    DateAnswerd = DateTimeOffset.Now,
                    QuestionChoiceId = int.Parse(answerId),
                    QuizId = quizId
                });
            }
            
            var result = await _context.SaveChangesAsync();
            if (result == 0)
                return 400;

            return 200;
        }
    }
}
