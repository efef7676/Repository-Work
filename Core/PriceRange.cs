namespace Core
{
    public class PriceRange
    {
        public double StartingPrice { get; set; }
        public double EndPrice { get; set; }

        public PriceRange(double startingPrice, double endPrice)
        {
            StartingPrice = startingPrice;
            EndPrice = endPrice;
        }

        public PriceRange(string priceRange)
        {
            var prices = priceRange.Split('-');
            StartingPrice = double.Parse(prices[0].Substring(1,4));
            EndPrice = double.Parse(prices[1].Substring(2, 4));
        }

        public string GetRange() => "$" + StartingPrice + " - " + "$" + EndPrice;

        public bool IsInRange(string price)
        {
            var newPrice = double.Parse(price.Substring(1));
            return newPrice>=StartingPrice||newPrice<=EndPrice;
        }
    }
}
