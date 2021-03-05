using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionary.Database.Context;
using Questionary.Database.Entity.Enum;

namespace Questionary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Allow")]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(QuestionGroup @group)
        {
            var data = await _context.QuestionModels.Where(x => x.Group == @group).Select(x => new
            {
                x.Id,
                x.Type,
                x.Question,
                Choice = x.QuestionChoiceModels.Select(c => new
                {
                    c.Id,
                    c.Choice,
                })
            }).ToListAsync();
            return Ok(data);
        }
    }
}
