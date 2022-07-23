using MediatR;
using TESTAPI.Core;
using TESTAPI.Services;

namespace TESTAPI.Handlers
{
    public class GetAll
    {
        public record Request(string Url) : IRequest<IEnumerable<Beer>>;

        public class Handler : IRequestHandler<Request, IEnumerable<Beer>>
        {
            private readonly IDataService dataService;

            public Handler(IDataService dataService)
            {
                this.dataService = dataService;
            }

            public async Task<IEnumerable<Beer>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await dataService.Load(request.Url);
            }

        }

    }
}
