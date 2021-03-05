using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Questionary.Api.Services;
using Questionary.Database.Entity.Enum;

namespace Questionary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Allow")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(
            IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<object> Get(int id)
        {
            var result = await _quizService.GetAsync(id);

            int code;
            if (int.TryParse(result.ToString(), out code))
            {
                return StatusCode(code);
            }

            return result;
        }

        [HttpPost]
        public async Task<object> Post([FromForm]string name, [FromForm]QuestionGroup @group = QuestionGroup.Json)
        {
            var result = await _quizService.AddAsync(name, group);

            int code;
            if (int.TryParse(result.ToString(), out code))
            {
                return StatusCode(code);
            }

            return result;
        }

        [HttpPut]
        public async Task<object> EndOfQuiz([FromForm]int id)
        {
            var result = await _quizService.UpdateAsync(id);
            return StatusCode(result);
        }
    }
}
