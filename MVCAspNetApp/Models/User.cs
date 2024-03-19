using System.ComponentModel.DataAnnotations;

namespace MVCAspNetApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Last_Name { get; set; }

        public string First_Name { get; set; }

        public string Email { get; set; }
    }
}
