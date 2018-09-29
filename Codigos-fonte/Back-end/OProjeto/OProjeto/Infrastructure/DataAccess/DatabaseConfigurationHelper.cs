using System;
using System.Configuration;

namespace OProjeto.Infrastructure.DataAccess
{
    /// <summary>
    /// Classe utilitária para configurações básicas do banco de dados
    /// </summary>
    public static class DatabaseConfigurationHelper
    {
        /// <summary>
        /// Método que solicita à classe de repositório que uma carga de dados seja feita
        /// </summary>
        public static void LoadWithInitialData()
        {
            StudentRepository.SeedDatabase();
        }
    }
}