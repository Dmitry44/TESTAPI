using Mediator;
using Microsoft.AspNetCore.Mvc;
using TESTAPI.Core;
using TESTAPI.Handlers;

namespace TESTAPI.Controllers
{
    [ApiController]
    [Route("api/beer")]
    public class BeerController : ControllerBase
    {
        private readonly IMediator mediator;

        public BeerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Beer>>> GetAll([FromQuery] string url)
        {
            return new JsonResult(await mediator.Send(new GetAll.Request(url)));
        }

        [HttpGet("price-exactly-17-99")]
        public async Task<ActionResult<IEnumerable<BeerFlat>>> GetPriceExactly1799([FromQuery] string url)
        {
            return new JsonResult(await mediator.Send(new GetPriceExactly.Request(url, 17.99m)));
        }

        public record CheapAndExpensiveBeersVm(
            IEnumerable<BeerFlat> CheapestBeers,
            IEnumerable<BeerFlat> MostExpensiveBeers);

        [HttpGet("cheapest-and-most-expensive-beers-per-liter")]
        public async Task<ActionResult<CheapAndExpensiveBeersVm>> GetCheapAndExpensiveBeersPerLiter([FromQuery] string url)
        {
            var cheapest = await mediator.Send(new GetCheapestBeersPerLiter.Request(url));
            var mostExpensive = await mediator.Send(new GetMostExpensiveBeersPerLiter.Request(url));

            return new JsonResult(new CheapAndExpensiveBeersVm(cheapest, mostExpensive));
        }

        [HttpGet("most-bottles")]
        public async Task<ActionResult<IEnumerable<BeerFlat>>> GetMostBottles([FromQuery] string url)
        {
            return new JsonResult(await mediator.Send(new GetMostBottles.Request(url)));
        }
    }
}
