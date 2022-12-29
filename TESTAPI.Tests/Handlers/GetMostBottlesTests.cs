using TESTAPI.Core;
using TESTAPI.Handlers;
using TESTAPI.Tests.Services;

namespace TESTAPI.Tests.Handlers
{
    [Collection("SetCultureInfo")]
    public class GetMostBottlesTests
    {
        [Fact]
        public async Task GetMostBottles_ShouldReturnBeers()
        {
            //arrange
            var dictBeers = new Dictionary<string, IEnumerable<Beer>>();

            dictBeers.Add("", new List<Beer>()
            {
                new Beer() { Id = 1,
                    Articles = new()
                    {
                        new() { Id = 11, ShortDescription = "20 x 0,5L (Glas)" },
                        new() { Id = 12, ShortDescription = "24 x 0,33L (Glas)" },
                        new() { Id = 13 }
                    }
                },
                new Beer() { Id = 2 },
                new Beer() { Id = 3 ,
                    Articles = new()
                    {
                        new() { Id = 32 },
                        new() { Id = 33, ShortDescription = "24 x 0,5L (Glas)" }
                    }
                },
                new Beer() { Id = 4 }
            });

            var sut = new GetMostBottles.Handler(new DataServiceFake(dictBeers));

            //act
            var rez = await sut.Handle(new GetMostBottles.Request(""), new CancellationToken());

            //assert
            Assert.NotNull(rez);
            Assert.NotEmpty(rez);
            Assert.True(rez.Count() == 2, "has 2 members");
            Assert.True(rez.Where(x => x.ArticleId == 12).Any(), "article 12 exists");
            Assert.True(rez.Where(x => x.ArticleId == 33).Any(), "article 33 exists");
        }

    }
}
