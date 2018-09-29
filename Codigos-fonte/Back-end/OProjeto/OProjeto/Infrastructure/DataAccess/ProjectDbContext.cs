using OProjeto.Models;
using System.Data.Entity;

namespace OProjeto.Infrastructure.DataAccess
{
    /// <summary>
    /// Classe que possibilita comunicar com a fonte de dados
    /// </summary>
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() //: base(DatabaseConfigurationHelper.GetConnectionString())
        {
            Configuration.LazyLoadingEnabled =
            Configuration.ProxyCreationEnabled =
            Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// Atribui/retorna uma referência à coleção de estudantes
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Método executado pelo runtime no momento da criação(ou mapeamento) do modelo com a fonte de dados
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var studentModelConfig = modelBuilder.Entity<Student>();
            studentModelConfig.ToTable("TB_ALUNO");
            studentModelConfig.HasKey(x => x.Id);
            studentModelConfig.Property(x => x.Ssn).HasColumnName("CPF").HasColumnType("VARCHAR").HasMaxLength(11).IsRequired();
            studentModelConfig.Property(x => x.FullName).HasColumnName("Nome").HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            studentModelConfig.Property(x => x.Address).HasColumnName("Endereco").HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            studentModelConfig.Property(x => x.State).HasColumnName("UF").HasColumnType("CHAR").HasMaxLength(2).IsRequired();
            studentModelConfig.Property(x => x.County).HasColumnName("Municipio").HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            studentModelConfig.Property(x => x.TelephoneNumber).HasColumnName("Telefone").HasColumnType("VARCHAR").HasMaxLength(15).IsRequired();
            studentModelConfig.Property(x => x.EmailAddress).HasColumnName("Email").HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            studentModelConfig.Property(x => x.Password).HasColumnName("Senha").HasColumnType("VARCHAR").HasMaxLength(1024).IsRequired();
        }
    }
}