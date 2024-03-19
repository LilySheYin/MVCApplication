using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAspNetApp.Models
{
    public class QuizQuestion
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Quiz")]
        public int QuizId { get; set; }

        public string Text { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}