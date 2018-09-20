using OProjeto.Models;
using System;
using System.Linq;

namespace OProjeto.Infrastructure.DataAccess
{
    /// <summary>
    /// Classe de repositório de alunos.
    /// Contém lógica de interação com a fonte de dados
    /// </summary>
    public class StudentRepository : IDisposable
    {
        private readonly ProjectDbContext dbContext;

        public StudentRepository(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Efetua a pesquisa na fonte de dados através das credenciais do aluno
        /// </summary>
        public Student GetByCredentials(string email, string password)
        {
            return dbContext.Students.FirstOrDefault(x => email == x.EmailAddress && x.Password == password);
        }

        /// <summary>
        /// Método disparado pelo runtime para livrar recursos da aplicação de maneira determinística
        /// </summary>
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}