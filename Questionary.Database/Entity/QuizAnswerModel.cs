using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionary.Database.Entity
{
    public class QuizAnswerModel
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset DateAnswerd { get; set; }

        [ForeignKey(nameof(QuizId))]
        public virtual QuizModel QuizModel { get; set; }
        public int QuizId { get; set; }

        [ForeignKey(nameof(QuestionChoiceId))]
        public virtual QuestionChoiceModel QuestionChoiceModel { get; set; }
        public int QuestionChoiceId { get; set; }
    }
}