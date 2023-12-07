using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SitemaComando.Models;
using System.IO;

namespace SitemaComando.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<FuncionarioModel> Funcionario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                string connString = config.GetConnectionString("SqlServer");
                optionsBuilder.UseSqlServer(connString);
            }
        }
    }
}
