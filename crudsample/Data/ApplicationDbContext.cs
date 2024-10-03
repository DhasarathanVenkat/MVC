using crudsample.Models;
using Microsoft.EntityFrameworkCore;

namespace crudsample.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Home> time { get; set; }
    }
     
}
