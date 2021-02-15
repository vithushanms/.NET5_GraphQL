using Microsoft.EntityFrameworkCore;
using QuestionQL.Models;

namespace QuestionQL.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        public DbSet<Question> QuestionDb {get; set;}
    }
}