using System.ComponentModel.DataAnnotations;

namespace DiverseTraining.DTOs
{
    public class UserRegisterDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        [StringLength(16, MinimumLength =4)]
        public string Password { get; set; }
        
        [Required]
        public string ConfirmPassword { get; set; }

    }
}