using OProjeto.Models.Abstract;

namespace OProjeto.Models
{
    /// <summary>
    /// Classe que contém os campos que caracterizam um estudante
    /// </summary>
    public class Student : Entity<long>
    {
        /// <summary>
        /// Atribui/retorna o CPF
        /// </summary>
        public string Ssn { get; set; }

        /// <summary>
        /// Atribui/retorna o Nome
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Atribui/retorna o Endereço
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Atribui/retorna o Município
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Atribui/retorna o Estado
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Atribui/retorna o Telefone
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Atribui/retorna o Endereço eletrônico de email
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Atribui/retorna a Senha
        /// </summary>
        public string Password { get; set; }
    }
}