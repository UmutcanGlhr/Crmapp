using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public String? Password { get; init; }
        [Required(ErrorMessage = "ConfirmPassword is required")]

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must be match")]
        public String? ConfirmPassword { get; init; }

    }
}