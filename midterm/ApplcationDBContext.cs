using Microsoft.EntityFrameworkCore;
using midterm.Models;

namespace midterm
{
    public class ApplcationDBContext : DbContext
    {
        public ApplcationDBContext(DbContextOptions<ApplcationDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}