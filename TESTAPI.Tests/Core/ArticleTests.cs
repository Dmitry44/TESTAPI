using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI.Core;

namespace TESTAPI.Tests.Core
{
    public class ArticleTests
    {
        [Fact]
        public void BeerPricePerUnit_ShoulReturnValue_WhenPricePerUnitTextCorrect()
        {
            //arrange
            var sut = new Article() { PricePerUnitText = "(2,50 €/Liter)" };

            //act
            var rez = sut.PricePerLiter;

            //assert
            Assert.Equal(2.5M, rez);
        }

        [Theory]
        [InlineData("")] //empty
        [InlineData(@"(2.50 €/Liter)")] //dot separator
        [InlineData(@"2,50 €/Liter)")] //no prefix
        [InlineData(@"2,50 €/Liter")] //no suffix
        [InlineData(@"2,5,0 €/Liter")] //double comma
        public void BeerPricePerUnit_ShoulReturnNull_WhenPricePerUnitTextWrong(string pricePerUnitText)
        {
            //arrange
            var sut = new Article() { PricePerUnitText = pricePerUnitText };

            //act
            var rez = sut.PricePerLiter;

            //assert
            Assert.Null(rez);
        }

    }

}
