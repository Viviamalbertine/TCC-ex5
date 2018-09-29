using OProjeto.Models;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Método que verifica se a tabela de alunos está ou não preenchida e, em caso negativo, executa uma carga inicial de dados
        /// </summary>
        public static void SeedDatabase()
        {
            var context = new ProjectDbContext();

            try
            {
                if (context.Students.Count() == 0)
                {
                    context.Students.AddRange(new List<Student>() {
                        new Student() { Ssn = "87558857805", FullName = "Adriana Selles", Address = "Rua Constelação de Sagitário, 121", State = "SP", County = "São Paulo", TelephoneNumber = "11987545623", EmailAddress = "adriana.selles@bol.com.br", Password = "0c65f376c526d32cf7b25a49715bcc6613485dfd511a599c5c2d87a29c0612cb" }, //@dri$E01#
                        new Student() { Ssn = "50562367640", FullName = "Rodrigo Mendes Souza Lima", Address = "Rua das Pitombeiras, 35", State = "SP", County = "São Paulo", TelephoneNumber = "11934885452", EmailAddress = "rm.lima@terra.com.br", Password = "79b009791ece5e0a8f82658542a8a06d9d6c353d975f820b2a0df80824302985" }, //ry0tO!@
                        new Student() { Ssn = "44621389700", FullName = "Cláudia Zakauskas Krzstoff", Address = "Avenida João Gabeira, 4529", State = "SP", County = "São Paulo", TelephoneNumber = "11996624565", EmailAddress = "claudiazk@myrealbox.com", Password = "3881769b9e2d89df151838cc947a7a549a968e807bcb018990589ccd7f1e66f5" }, //cL@ud1@2018
                        new Student() { Ssn = "40491556489", FullName = "Márcio Di Marzio", Address = "Avenida Rubem Berta, 1252", State = "SP", County = "São Paulo", TelephoneNumber = "11971005458", EmailAddress = "mdmz@outlook.com", Password = "ad977964c01b8315b6b6e0fefc48be1015178c08d83fa55ed9475ab917d5c30b" }, //M@rz!021082009
                        new Student() { Ssn = "56165063705", FullName = "Suzana Tavares Alvarenga", Address = "Alameda Arapanés, 455", State = "SP", County = "São Paulo", TelephoneNumber = "11912129642", EmailAddress = "stalvarenga@hotmail.com", Password = "84ccd133d41f7f0d38c3dc72b6aec89659dc849c0e3c389c1618eaa6822df3ec" } //@lvarenga!$*
                    });

                    context.SaveChanges();
                }
            }
            catch (Exception) { }
        }
    }
}