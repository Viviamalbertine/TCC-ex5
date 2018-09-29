using OProjeto.Infrastructure.DataAccess;
using OProjeto.Infrastructure.Security.Hashing;
using OProjeto.Models;
using System;

namespace OProjeto.Services
{
    /// <summary>
    /// Classe que contém métodos de interação com a entidade Aluno.
    /// Depende de uma instância da classe de repositório de alunos para enviar dados à fonte de dados
    /// </summary>
    public class StudentServices : IDisposable
    {
        private readonly StudentRepository studentRepository;
        private readonly HashProvider hashProvider;

        public StudentServices(StudentRepository studentRepository, HashProvider hashProvider)
        {
            this.studentRepository = studentRepository;
            this.hashProvider = hashProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Student Authenticate(string email, string password)
        {
            var hashedPassword = hashProvider.ComputeHash(password);

            return studentRepository.GetByCredentials(email, hashedPassword);
        }

        /// <summary>
        /// Método disparado pelo runtime para livrar recursos da aplicação de maneira determinística
        /// </summary>
        public void Dispose()
        {
            studentRepository.Dispose();
        }
    }
}
