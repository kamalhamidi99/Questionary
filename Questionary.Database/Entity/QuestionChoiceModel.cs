using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionary.Database.Entity
{
    public class QuestionChoiceModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Choice { get; set; }

        public bool IsAnswer { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public virtual QuestionModel QuestionModel { get; set; }
        public int QuestionId { get; set; }

        public virtual ICollection<QuizAnswerModel> QuizAnswerModels { get; set; }
    }
}