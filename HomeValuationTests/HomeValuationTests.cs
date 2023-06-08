using Microsoft.EntityFrameworkCore;
using Xunit;
using HomeValuationBackend.Models;
using HomeValuationBackend.Managers;


namespace HomeValuationTests
{
    public class HomeValuationTests
    {
        private readonly HomeValuationManager _manager;

        public HomeValuationTests()
        {
            DbContextOptions<HomeValuationContext> options = GetDbContextOptions();

            HomeValuationContext context = new HomeValuationContext(options);

            _manager = new HomeValuationManager(context);
        }

        private DbContextOptions<HomeValuationContext> GetDbContextOptions()
        {

            DbContextOptionsBuilder<HomeValuationContext> optionsBuilder = new DbContextOptionsBuilder<HomeValuationContext>();
            optionsBuilder.UseSqlServer("Server=tcp:math6799.database.windows.net,1433;Initial Catalog=math6799;Persist Security Info=False;User ID=math6799@edu.zealand.dk;Password=Zeas4p8w!2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";");

            return optionsBuilder.Options;
        }

        [Fact]
        public void GetAllTest_ShouldPass()
        {
            IEnumerable<Home> homes = _manager.GetAll();

            Assert.Equal(317, homes.Count());
        }

        [Fact]
        public void GetByIdTest()
        {
            Home home = _manager.GetById(1);

            Assert.Equal(1, home.Id);
        }

        [Fact]
        public void AvgKvmPriceTest()
        {
            // ARRANGE - define a variable showing the expected results with decimals
            double d = 29694;

            // ACT - use math round to remove decimals
            double dc = Math.Round((double)d, 0);

            // ASSERT - takes the new variable and compares it to the method outcome
            Assert.Equal(dc, _manager.AvgSqmPriceInMunicipality(1));
        }

        [Fact]
        public void CalculateSingleHomeTest()
        {
            // Arrange

            // Define test input values
            int municipalityId = 1;
            int squareMeters = 100;
            int constructionYear = 2005;
            string energyLabel = "C";

            // Define expected result
            double expectedAdjustedPrice = 3299003;

            // Act
            double actualAdjustedPrice = _manager.CalculateSingleHome(municipalityId, squareMeters, constructionYear, energyLabel);

            // Assert
            Assert.Equal(expectedAdjustedPrice, actualAdjustedPrice);
        }
    }
}