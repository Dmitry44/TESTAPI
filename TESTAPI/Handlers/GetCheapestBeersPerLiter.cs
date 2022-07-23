using MediatR;
using TESTAPI.Core;
using TESTAPI.Services;

namespace TESTAPI.Handlers
{
    public class GetCheapestBeersPerLiter
    {
        public record Request(string Url) : IRequest<IEnumerable<BeerFlat>>;

        public class Handler : IRequestHandler<Request, IEnumerable<BeerFlat>>
        {
            private readonly IDataService dataService;

            public Handler(IDataService dataService)
            {
                this.dataService = dataService;
            }

            public async Task<IEnumerable<BeerFlat>> Handle(Request request, CancellationToken cancellationToken)
            {
                var data = await dataService.Load(request.Url);

                var minPrice = data.Min(x => x.Articles.Min(a => a.PricePerLiter));

                return data
                    .SelectMany(x => x.Articles.Select(a => new BeerFlat(x, a)))
                    .Where(x => x.PricePerLiter == minPrice);
            }

        }

    }
}
