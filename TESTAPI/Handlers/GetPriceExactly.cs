using Mediator;
using TESTAPI.Core;
using TESTAPI.Services;

namespace TESTAPI.Handlers
{
    public class GetPriceExactly
    {
        public record Request(string Url, decimal Price) : IRequest<IEnumerable<BeerFlat>>;

        public class Handler : IRequestHandler<Request, IEnumerable<BeerFlat>>
        {
            private readonly IDataService dataService;

            public Handler(IDataService dataService)
            {
                this.dataService = dataService;
            }

            public async ValueTask<IEnumerable<BeerFlat>> Handle(Request request, CancellationToken cancellationToken)
            {
                var data = await dataService.Load(request.Url);

                //return data
                //    .Where(x => x.Articles.Any(a => a.Price == request.Price))
                //    .Select(x => new Beer() {
                //        Id = x.Id,
                //        Name = x.Name,
                //        BrandName = x.BrandName,
                //        Articles = x.Articles.Where(x => x.Price == request.Price).OrderBy(x => x.PricePerLiter).ToList()
                //    });

                return data
                    .SelectMany(x =>x.Articles
                        .Where(a => a.Price == request.Price)
                        .Select(a => new BeerFlat(x, a)))
                    .OrderBy(x => x.PricePerLiter);
            }

        }

    }
}
