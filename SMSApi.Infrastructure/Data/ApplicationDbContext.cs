using Microsoft.EntityFrameworkCore;
using SMSApi.Core.Models;

namespace SMSApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                        
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}
