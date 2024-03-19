using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAspNetApp.Models
{
    public class QuizQuestionOption
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("QuizQuestion")]
        public int QuizQuestionId { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public virtual QuizQuestion QuizQuestion { get; set; }
    }
}