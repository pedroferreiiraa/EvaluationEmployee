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
            modelBuilder.Entity<Avaliation>()
                .HasMany(a => a.Answers)
                .WithOne(ans => ans.Avaliation)
                .HasForeignKey(ans => ans.AvaliationId);

            modelBuilder.Entity<Answer>()
                .HasOne(ans => ans.Question)
                .WithMany()
                .HasForeignKey(ans => ans.QuestionId);

            modelBuilder.Entity<Answer>()
                .HasIndex(ans => new { ans.AvaliationId, ans.QuestionId })
                .IsUnique();
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Gestor)
                .WithMany()
                .HasForeignKey(d => d.GestorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Lider)
                .WithMany()
                .HasForeignKey(d => d.LiderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId);

        }

    }
}
