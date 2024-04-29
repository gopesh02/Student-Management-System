using Microsoft.EntityFrameworkCore;
using ModelLayer;

namespace DataAcccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<StudentModel> StudentModels { get; set; }
        public DbSet<CourseModel> CourseModels { get; set;} 
    }
}
