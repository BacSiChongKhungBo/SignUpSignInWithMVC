using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
