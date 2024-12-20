using _5W2H.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace _5W2H.Infrastructure.Persistence
{
    public class EvaluationDbContext : DbContext
    {
        public class WhoDbContextFactory : IDesignTimeDbContextFactory<EvaluationDbContext>
        {
            public EvaluationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<EvaluationDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);

                return new EvaluationDbContext(optionsBuilder.Options);
            }
        }

        public EvaluationDbContext(DbContextOptions<EvaluationDbContext> options) : base(options) { }

        // Definição dos DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<UserEvaluation> UserAvaliations { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
        public DbSet<Answer> UserAnswers { get; set; }
        public DbSet<LeaderEvaluation> LeaderAvaliations { get; set; }
        public DbSet<LeaderQuestion> LeaderQuestions { get; set; }
        public DbSet<LeaderAnswer> LeaderAnswers { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEvaluation>()
                .HasMany(a => a.Answers)
                .WithOne(ans => ans.UserEvaluation)
                .HasForeignKey(ans => ans.AvaliationId);
            
            modelBuilder.Entity<LeaderEvaluation>()
                .HasMany(a => a.LeaderAnswers)
                .WithOne(ans => ans.LeaderEvaluation)
                .HasForeignKey(ans => ans.AvaliationId);

            modelBuilder.Entity<Answer>()
                .HasOne(ans => ans.UserQuestion)
                .WithMany()
                .HasForeignKey(ans => ans.QuestionId);
            
            modelBuilder.Entity<LeaderAnswer>()
                .HasOne(ans => ans.LeaderQuestion)
                .WithMany()
                .HasForeignKey(ans => ans.QuestionId);

            modelBuilder.Entity<Answer>()
                .HasIndex(ans => new { ans.AvaliationId, ans.QuestionId })
                .IsUnique();
            
            modelBuilder.Entity<LeaderAnswer>()
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
