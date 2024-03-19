using System.ComponentModel.DataAnnotations;

public class Quiz
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
}
