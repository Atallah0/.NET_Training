using Domain.Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext
{
    public class LearningContext : DbContext
    {
        public LearningContext(DbContextOptions<LearningContext> options) : base(options)
        {
        }

        public DbSet<Domain.Project.Models.Project> Projects { get; set; }
    }
}