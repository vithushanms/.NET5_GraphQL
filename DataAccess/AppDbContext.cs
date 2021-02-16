using Microsoft.EntityFrameworkCore;
using QuestionQL.Models;

namespace QuestionQL.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        public DbSet<Question> Questions {get; set;}
        public DbSet<Answer> Answers {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder
            .Entity<Question>()
            .HasMany(a => a.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

            modelBuilder
            .Entity<Answer>()
            .HasOne(q => q.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(q => q.QuestionId);
        }
    }
}