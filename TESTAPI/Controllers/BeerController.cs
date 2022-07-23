using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAll([FromQuery] string url)
        {
            return new JsonResult(await mediator.Send(new GetAll.Request(url)));
        }

        [HttpGet("price-exactly-17-99")]
        public async Task<IActionResult> GetPriceExactly1799([FromQuery] string url)
        {
            return new JsonResult(await mediator.Send(new GetPriceExactly.Request(url, 17.99m)));
        }

        [HttpGet("cheapest-and-most-expensive-beers-per-liter")]
        public async Task<IActionResult> CheapestAndMostExpensiveBeersPerLiter([FromQuery] string url)
        {
            var cheapest = await mediator.Send(new GetCheapestBeersPerLiter.Request(url));
            var mostExpensive = await mediator.Send(new GetMostExpensiveBeersPerLiter.Request(url));

            return new JsonResult(new { cheapest, mostExpensive });
        }

        [HttpGet("most-bottles")]
        public IActionResult GetMostBottles([FromQuery] string url)
        {
            return new JsonResult(new { });
        }
    }
}
