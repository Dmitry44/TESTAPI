namespace TESTAPI.Core
{
    public class BeerFlat
    {
        public BeerFlat()
        {

        }

        public BeerFlat(Beer beer, Article article)
        {
            BeerId = beer.Id;
            BrandName = beer.BrandName;
            Name = beer.Name;

            ArticleId = article.Id;
            ShortDescription = article.ShortDescription;
            Unit = article.Unit;
            Image = article.Image;
            Price = article.Price;
            PricePerUnitText = article.PricePerUnitText;
            PricePerLiter = article.PricePerLiter;
        }

        public int BeerId { get; set; }

        public string BrandName { get; set; } = "";

        public string Name { get; set; } = "";

        public int ArticleId { get; set; }

        public string ShortDescription { get; set; } = "";

        public string Unit { get; set; } = "";

        public string Image { get; set; } = "";

        public decimal Price { get; set; }

        public string PricePerUnitText { get; set; } = "";

        public decimal? PricePerLiter { get; set; }

    }
}
