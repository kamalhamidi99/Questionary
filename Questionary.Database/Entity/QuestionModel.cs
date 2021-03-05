using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Questionary.Database.Entity.Enum;

namespace Questionary.Database.Entity
{
    public class QuestionModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(500)]
        public string Question { get; set; }

        public QuestionType Type { get; set; }

        public QuestionGroup Group { get; set; }

        public virtual ICollection<QuestionChoiceModel> QuestionChoiceModels { get; set; }
    }
}