using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condo.Core.Requests.Identity
{
    public class RegisterUserRequest : Request
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Celular é obrigatório")]
        [Phone(ErrorMessage = "O número de celular fornecido não é válido.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "O celular deve ter entre 10 e 15 caracteres.")]
        public string Celular { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(100, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
            ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial.")]
        public string Password { get; set; } = string.Empty;
    }
}
