using Microsoft.EntityFrameworkCore;
using SimpleLibraryAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryAuthentication.DAL
{
    /// <summary>
    /// Contexto do banco de dados para a aplicação.
    /// Gerencia a conexão e as operações com o banco de dados MSSQL.
    /// ----------------------------------------------------------------
    /// Dicas:
    /// ----------------------------------------------------------------
    /// var builder = WebApplication.CreateBuilder(args);
    /// 
    /// // Configurando o DbContext com a string de conexão do appsettings.json
    /// builder.Services.AddDbContext<MyDbContext>(options =>
    /// options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    /// 
    /// // Adicionar serviços ao contêiner.
    /// builder.Services.AddControllersWithViews();
    /// 
    /// var app = builder.Build();
    /// 
    /// // Código adicional...
    /// 
    /// app.Run();
    /// </summary>
    public class MyDbContext : DbContext
    {
        /// <summary>
        /// Construtor do MyDbContext que aceita opções de configuração.
        /// </summary>
        /// <param name="options">Opções de configuração do DbContext.</param>
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Conjunto de entidades representando os usuários no banco de dados.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Configurações adicionais do modelo.
        /// </summary>
        /// <param name="modelBuilder">Construtor do modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de mapeamento para a entidade User, se necessário.
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username); // Define Username como chave primária
                entity.Property(e => e.Username)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                      .IsRequired();
            });
        }
    }
}
