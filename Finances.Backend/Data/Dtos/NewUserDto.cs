using System.ComponentModel.DataAnnotations;

namespace Finances.Backend.Data.Dtos
{
    public class NewUserDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "O username deve possuir no mínimo 5 caractéres!")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Data inválida!")]
        public DateTime Birth { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(12, ErrorMessage = "A senha deve possúir no mínimo 12 caracteres!")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Confirmação de senha inválida!")]
        [MinLength(12, ErrorMessage = "A confirmação de senha deve possúir no mínimo 12 caracteres!")]
        public string PasswordConfirmation { get; set; }
    }
}
