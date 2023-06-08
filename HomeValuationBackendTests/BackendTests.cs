using Microsoft.EntityFrameworkCore;
using Xunit;
using HomeValuationBackend.Models;
using HomeValuationBackend.Managers;

namespace HomeValuationBackendTests
{
    public class BackendTests
    {
        private readonly HomeValuationManager _manager;

        public BackendTests()
        {
            // Retrieve appropriate DbContextOptions from your configuration
            DbContextOptions<HomeValuationContext> options = GetDbContextOptions();

            // Create an instance of HomePriceValuationContext using the options
            HomeValuationContext context = new HomeValuationContext(options);

            // Instantiate HomePriceValuationManager by passing the context
            _manager = new HomeValuationManager(context);
        }

        private DbContextOptions<HomeValuationContext> GetDbContextOptions()
        {
            // Implement the logic to retrieve and configure your DbContextOptions here
            // Return the configured options

            // Example implementation:
            DbContextOptionsBuilder<HomeValuationContext> optionsBuilder = new DbContextOptionsBuilder<HomeValuationContext>();
            optionsBuilder.UseSqlServer("Server=tcp:math6799.database.windows.net,1433;Initial Catalog=math6799;Persist Security Info=False;User ID=math6799@edu.zealand.dk;Password=Zeas4p8w!2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";");

            return optionsBuilder.Options;
        }
    }
}