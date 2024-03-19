using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAspNetApp.Models
{
    public class QuizUserAnswer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("QuizQuestion")]
        public int QuizQuestionId { get; set; }

        [ForeignKey("QuizQuestionOption")]
        public int QuizQuestionOptionId { get; set; }

        public virtual QuizQuestion QuizQuestion { get; set; }

        public virtual QuizQuestionOption QuizQuestionOption { get; set; }
    }
}