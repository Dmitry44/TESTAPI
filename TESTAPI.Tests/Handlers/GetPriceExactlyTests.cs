using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI.Core;
using TESTAPI.Handlers;
using TESTAPI.Tests.Services;

namespace TESTAPI.Tests.Handlers
{
    public class GetPriceExactlyTests
    {
        [Fact]
        public async Task GetPriceExactly_ShouldReturnBeers()
        {
            //arrange
            var dictBeers = new Dictionary<string, IEnumerable<Beer>>();

            dictBeers.Add("", new List<Beer>()
            {
                new Beer() { Id = 1,
                    Articles = new()
                    {
                        new() { Id = 11, Price = 1, PricePerUnitText = "(3,0 €/Liter)" },
                        new() { Id = 12, Price = 1, PricePerUnitText = "(2,0 €/Liter)" },
                        new() { Id = 13, Price = 2 }
                    }
                },
                new Beer() { Id = 2 },
                new Beer() { Id = 3 ,
                    Articles = new()
                    {
                        new() { Id = 32, Price = 2 },
                        new() { Id = 33, Price = 1, PricePerUnitText = "(1,0 €/Liter)" }
                    }
                },
                new Beer() { Id = 4 }
            });

            var sut = new GetPriceExactly.Handler(new DataServiceFake(dictBeers));

            //act
            var rez = await sut.Handle(new GetPriceExactly.Request("", 1), new CancellationToken());

            //assert
            Assert.NotNull(rez);
            Assert.NotEmpty(rez);
            Assert.True(rez.Count() == 3, "has 3 members");
            Assert.True(rez.Where(x => x.ArticleId == 11).Any(), "article 11 exists");
            Assert.True(rez.Where(x => x.ArticleId == 12).Any(), "article 12 exists");
            Assert.False(rez.Where(x => x.ArticleId == 13).Any(), "article 13 doesn't exists");
            Assert.False(rez.Where(x => x.ArticleId == 32).Any(), "article 32 doesn't exists");
            Assert.True(rez.Where(x => x.ArticleId == 33).Any(), "article 33 exists");
            Assert.True(rez.First().ArticleId == 33, "article 33 first");
            Assert.True(rez.Last().ArticleId == 11, "article 11 last");
        }

    }
}
