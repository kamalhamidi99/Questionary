using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Questionary.Database.Entity.Enum;

namespace Questionary.Database.Entity
{
    public class QuizModel
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset DateStarted { get; set; }

        public DateTimeOffset? DateEnded { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserModel UserModel { get; set; }
        public int UserId { get; set; }

        public QuestionGroup QuestionGroup { get; set; }

        public virtual ICollection<QuizAnswerModel> QuizAnswerModels { get; set; }
    }
}