using System.Collections.Generic;
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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(
            IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> Get(QuestionGroup @group)
        {
            return await _questionService.GetAllAsync(group);
        }
    }
}
