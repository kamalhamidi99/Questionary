using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Questionary.Api.Controllers;
using Questionary.Api.Services;
using Questionary.Database.Entity.Enum;

namespace Questionary.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public async Task CheckTheTotalOfQuestions()
        {
            var service = new Mock<IQuestionService>();

            service.Setup(x => x.GetAllAsync(QuestionGroup.Json)).ReturnsAsync(new List<QuestionDto>()
            {
                new QuestionDto(),
                new QuestionDto(),
                new QuestionDto()
            });

            var controller = new QuestionController(service.Object);

            var results = await controller.Get(QuestionGroup.Json);

            Assert.AreEqual(results.Count(), 3);
        }
    }
}
