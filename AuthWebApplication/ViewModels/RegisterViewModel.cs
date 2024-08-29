using System.ComponentModel.DataAnnotations;

namespace AuthWebApplication.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        public string Username { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&_])[A-Za-z\\d@$!%*?&_]{8,}$",
            ErrorMessage = "Password should be 8 digits or more and have uppercase , lowercase alphabet,numbers and special characters")]

        public string Password { get; set; } = string.Empty;

        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;


        [Required]
        public IFormFile ImageFile { get; set; } 








    }
}
