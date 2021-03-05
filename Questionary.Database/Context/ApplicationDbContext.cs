using Microsoft.EntityFrameworkCore;
using Questionary.Database.Entity;
using Questionary.Database.Entity.Enum;

namespace Questionary.Database.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<QuestionModel> QuestionModels { get; set; }
        public DbSet<QuestionChoiceModel> QuestionChoiceModels { get; set; }
        public DbSet<QuizModel> QuizModels { get; set; }
        public DbSet<QuizAnswerModel> QuizAnswerModels { get; set; }

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionModel>().HasData(
                new QuestionModel()
                {
                    Id = 1,
                    Question = "By convention, what name is used for the first key in a JSON schema?",
                    Type = QuestionType.SingleAnswer,
                    Group = QuestionGroup.Json,
                },
                new QuestionModel()
                {
                    Id = 2,
                    Question = "Which JavaScript method converts a JavaScript value to Json?",
                    Type = QuestionType.SingleAnswer,
                    Group = QuestionGroup.Json,
                },
                new QuestionModel()
                {
                    Id = 3,
                    Question = "Which data type is part of JSON standard?",
                    Type = QuestionType.MultiAnswers,
                    Group = QuestionGroup.Json,
                }
            );

            modelBuilder.Entity<QuestionChoiceModel>().HasData(
                new QuestionChoiceModel()
                {
                    Id = 1,
                    Choice = "schema",
                    QuestionId = 1,
                },
                new QuestionChoiceModel()
                {
                    Id = 2,
                    Choice = "$schema",
                    IsAnswer = true,
                    QuestionId = 1,
                },
                new QuestionChoiceModel()
                {
                    Id = 3,
                    Choice = "JsonSchema",
                    QuestionId = 1,
                },
                new QuestionChoiceModel()
                {
                    Id = 4,
                    Choice = "JSONschema",
                    QuestionId = 1,
                },
                new QuestionChoiceModel()
                {
                    Id = 5,
                    Choice = "JSON.parse()",
                    QuestionId = 2,
                },
                new QuestionChoiceModel()
                {
                    Id = 6,
                    Choice = "JSON.stringify()",
                    IsAnswer = true,
                    QuestionId = 2,
                },
                new QuestionChoiceModel()
                {
                    Id = 7,
                    Choice = "JSON.toString()",
                    QuestionId = 2,
                },
                new QuestionChoiceModel()
                {
                    Id = 8,
                    Choice = "JSON.objectify()",
                    QuestionId = 2,
                },
                new QuestionChoiceModel()
                {
                    Id = 9,
                    Choice = "string",
                    IsAnswer = true,
                    QuestionId = 3,
                },
                new QuestionChoiceModel()
                {
                    Id = 10,
                    Choice = "number",
                    IsAnswer = true,
                    QuestionId = 3,
                },
                new QuestionChoiceModel()
                {
                    Id = 11,
                    Choice = "date",
                    QuestionId = 3,
                },
                new QuestionChoiceModel()
                {
                    Id = 12,
                    Choice = "array",
                    IsAnswer = true,
                    QuestionId = 3,
                }
            );
        }

        #endregion
    }
}