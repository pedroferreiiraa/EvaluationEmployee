// File: _5W2H.Infrastructure.Persistence/WhoDbContext.cs

using _5W2H.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace _5W2H.Infrastructure.Persistence
{
    public class WhoDbContext : DbContext
    {
        public class WhoDbContextFactory : IDesignTimeDbContextFactory<WhoDbContext>
        {
            public WhoDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<WhoDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);

                return new WhoDbContext(optionsBuilder.Options);
            }
        }

        public WhoDbContext(DbContextOptions<WhoDbContext> options) : base(options) { }

        // Definição dos DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Avaliation> Avaliations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração de relacionamento para 'Lider' em 'Department'
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Lider)
                .WithMany()
                .HasForeignKey(d => d.LiderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de relacionamento para 'Gestor' em 'Department'
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Gestor)
                .WithMany()
                .HasForeignKey(d => d.GestorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração existente para 'Avaliation'
            modelBuilder.Entity<Avaliation>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Avaliation>()
                .HasOne(a => a.Avaliador)
                .WithMany()
                .HasForeignKey(a => a.AvaliadorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração existente para 'Answer'
            modelBuilder.Entity<Answer>()
                .HasOne(r => r.Avaliation)
                .WithMany(a => a.Answers)
                .HasForeignKey(r => r.AvaliationId);

            modelBuilder.Entity<Answer>()
                .HasOne(r => r.Question)
                .WithMany()
                .HasForeignKey(r => r.QuestionId);
        }

    }
}
