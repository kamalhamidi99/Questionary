using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questionary.Database.Context;
using Questionary.Database.Entity.Enum;

namespace Questionary.Api.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetAllAsync(QuestionGroup @group);
    }

    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;

        public QuestionService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionDto>> GetAllAsync(QuestionGroup @group)
        {
            return await _context.QuestionModels.Where(x => x.Group == @group).Select(x => new QuestionDto
            {
                Id = x.Id,
                Type = x.Type,
                Question = x.Question,
                Choices = x.QuestionChoiceModels.Select(c => new QuestionDto.ChoiceDto
                {
                    Id = c.Id,
                    Choice = c.Choice
                }).ToList()
            }).ToListAsync();
        }
    }

    public class QuestionDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionType Type { get; set; }
        public QuestionGroup Group { get; set; }
        public IList<ChoiceDto> Choices { get; set; }

        public class ChoiceDto
        {
            public int Id { get; set; }
            public string Choice { get; set; }
        }
    }
}
