using GamesApi.Infra.Repository.Configure;
using Microsoft.EntityFrameworkCore;

namespace GamesApi.Infra.Repository
{
    public class AmiibooDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        //public AmiibooDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public AmiibooDbContext(DbContextOptions<AmiibooDbContext> opt) : base(opt)
        {
        }

        public DbSet<Amiibo> Amiibo { get; set; }
        public DbSet<Amiibooo> AmiiboLog { get; set; }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{
        //    optionBuilder.UseMySql(_configuration.GetValue<string>("ConnectionStrings:MySql"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmiiboConfiguration());
            modelBuilder.ApplyConfiguration(new AmiiboLogConfiguration());
        }


        //Migration
        //https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

        //para criar a primeira migração
        //add-migration <NomeDaSuaMigracao>

        //Vai até o banco e executa a migration (criar e alterar schema,banco de dados, tabela )
        //Update-Database

        //para alterar tabela
        //add-migration <nomeDaMigracao>


        //Caso queira remover alguma migration(sem nome remove a ultima)
        // Remove-Migration 

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IdentityUser>()
        //        .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
        //    }
        //}
    }
}