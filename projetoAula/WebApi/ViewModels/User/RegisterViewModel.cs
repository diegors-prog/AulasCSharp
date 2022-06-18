using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O password é obrigatório")]
        public string Password { get; set; }
    }
}