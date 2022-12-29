﻿using TESTAPI.Core;
using TESTAPI.Handlers;
using TESTAPI.Tests.Services;

namespace TESTAPI.Tests.Handlers
{
    [Collection("SetCultureInfo")]
    public class GetMostExpensiveBeersPerLiterTests
    {
        [Fact]
        public async Task GetCheapestBeersPerLiter_ShouldReturnBeers()
        {
            //arrange
            var dictBeers = new Dictionary<string, IEnumerable<Beer>>();

            dictBeers.Add("", new List<Beer>()
            {
                new Beer() { Id = 1,
                    Articles = new()
                    {
                        new() { Id = 11, Price = 1, PricePerUnitText = "(1,0 €/Liter)" },
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

            var sut = new GetMostExpensiveBeersPerLiter.Handler(new DataServiceFake(dictBeers));

            //act
            var rez = await sut.Handle(new GetMostExpensiveBeersPerLiter.Request(""), new CancellationToken());

            //assert
            Assert.NotNull(rez);
            Assert.NotEmpty(rez);
            Assert.True(rez.Count() == 1, "has 1 member");
            Assert.True(rez.Where(x => x.ArticleId == 12).Any(), "article 12 exists");
        }
        
    }
}
