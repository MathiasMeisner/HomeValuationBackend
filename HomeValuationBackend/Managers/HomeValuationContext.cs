using HomeValuationBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeValuationBackend.Managers
{
    public class HomeValuationContext : DbContext
    {
        public HomeValuationContext(DbContextOptions<HomeValuationContext> options) : base(options)
        {

        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Municipality> Municipality { get; set; }
    }
}
