using System.ComponentModel.DataAnnotations;

namespace Finances.Backend.Data.Dtos
{
    public class NewUserDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "O username deve possuir no mínimo 5 caractéres!")]
        public string Username { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
