﻿using TESTAPI.Services;

namespace TESTAPI.Tests.Services
{
    [Collection("SetCultureInfo")]
    public class DataServiceTests
    {
        //[Fact]
        public async Task DataService_ShouldReturnBeersFromRealUrl()
        {
            //arrange
            var sut = new DataService(new HttpClient());

            //act
            var rez = await sut.Load("https://flapotest.blob.core.windows.net/test/ProductData.json");

            //assert
            Assert.NotNull(rez);
            Assert.NotEmpty(rez);
            Assert.False(String.IsNullOrEmpty(rez.First().Name));
        }

    }
}
