using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionary.Database.Context;
using Questionary.Database.Entity;

namespace Questionary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Allow")]
    public class QuizAnswerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuizAnswerController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] int quizId, [FromForm] string answerIds)
        {
            var quiz = await _context.QuizModels.FirstOrDefaultAsync(x => x.Id == quizId);
            if (quiz == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(answerIds))
                return BadRequest();

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
                return BadRequest();

            return Ok();
        }
    }
}
