using System;
using System.ComponentModel.DataAnnotations;

namespace OProjeto.ViewModels
{
    /// <summary>
    /// Classe que representa dados utilizados para fins de autenticação
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Propriedade que retorna/atribui o nome do usuário
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Propriedade que retorna/atribui a senha do usuário
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}