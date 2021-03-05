using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionary.Database.Entity
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<QuizModel> QuizModels { get; set; }
    }
}