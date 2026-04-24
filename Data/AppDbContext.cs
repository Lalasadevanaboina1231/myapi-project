using Microsoft.EntityFrameworkCore;
using myapiproject.Models;
 
namespace myapiproject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
 
        public DbSet<Product> Products { get; set; }
    }
}