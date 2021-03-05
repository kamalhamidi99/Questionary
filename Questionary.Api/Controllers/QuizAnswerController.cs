using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Questionary.Api.Services;

namespace Questionary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Allow")]
    public class QuizAnswerController : ControllerBase
    {
        private readonly IQuizAnswerService _quizAnswerService;

        public QuizAnswerController(
            IQuizAnswerService quizAnswerService)
        {
            _quizAnswerService = quizAnswerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] int quizId, [FromForm] string answerIds)
        {
            var result = await _quizAnswerService.AddAsync(quizId, answerIds);
            return StatusCode(result);
        }
    }
}
