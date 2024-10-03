using System.ComponentModel.DataAnnotations;

namespace crudsample.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage ="Name Should Contain Only Alpahbets")]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public long Password { get; set; }

    }
}
