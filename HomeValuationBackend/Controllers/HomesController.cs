using Microsoft.AspNetCore.Mvc;
using HomeValuationBackend.Models;
using HomeValuationBackend.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly HomeValuationManager _manager;

        public HomesController(HomeValuationContext context)
        {
            _manager = new HomeValuationManager(context);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Home> GetAllHomes()
        {
            IEnumerable<Home> homes = _manager.GetAll();
            return homes;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Home> GetById(int id)
        {
            Home home = _manager.GetById(id);
            if (home == null) return NotFound("No id: " + id);
            return home;
        }

        [HttpGet("avgsqm/{municipalityId}")]
        public IActionResult GetAverageSqmPriceInMunicipality(int municipalityId)
        {
            double averageSqmPrice = _manager.AvgSqmPriceInMunicipality(municipalityId);
            return Ok(averageSqmPrice);
        }

        [HttpGet("singlehome")]
        public IActionResult GetSingleHomePrice(int municipalityId, int squareMeters, int constructionYear, string energyLabel)
        {
            double adjustedPrice = _manager.CalculateSingleHome(municipalityId, squareMeters, constructionYear, energyLabel);

            return Ok(adjustedPrice);
        }
    }
}
