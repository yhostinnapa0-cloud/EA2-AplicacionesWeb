using System.ComponentModel.DataAnnotations;

namespace EcoStore.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese su correo electrónico.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese su contraseña.")]
        public string Password { get; set; } = string.Empty;
    }
}