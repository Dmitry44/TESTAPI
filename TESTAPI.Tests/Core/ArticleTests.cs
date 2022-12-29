using TESTAPI.Core;

namespace TESTAPI.Tests.Core
{
    [Collection("SetCultureInfo")]
    public class ArticleTests
    {
        [Fact]
        public void BeerPricePerUnit_ShouldReturnValue_WhenPricePerUnitTextCorrect()
        {
            //arrange
            
            //act
            var sut = new Article() { PricePerUnitText = "(2,50 €/Liter)" };
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
        public void BeerPricePerUnit_ShouldReturnNull_WhenPricePerUnitTextWrong(string pricePerUnitText)
        {
            //arrange

            //act
            var sut = new Article() { PricePerUnitText = pricePerUnitText };
            var rez = sut.PricePerLiter;

            //assert
            Assert.Null(rez);
        }

        [Theory]
        [InlineData("20 x 0,33L (Glas)", 20, 0.33)]
        [InlineData("5 x 1L (Glas)", 5, 1)]
        public void ShortDescription_ShouldBeParsed_WhenValueCorrect(string shortDescription, int cnt, decimal vlm)
        {
            //arrange

            //act
            var sut = new Article() { ShortDescription = shortDescription };

            //assert
            Assert.Equal(cnt, sut.BottleCount);
            Assert.Equal(vlm, sut.BottleVolume);
        }

        [Theory]
        [InlineData("")]
        [InlineData("5 x 1 L (Glas)")]
        public void ShortDescription_ShouldSetNull_WhenValueIncorrect(string shortDescription)
        {
            //arrange

            //act
            var sut = new Article() { ShortDescription = shortDescription };

            //assert
            Assert.Null(sut.BottleCount);
            Assert.Null(sut.BottleVolume);
        }

    }

}
