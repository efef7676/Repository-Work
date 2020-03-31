namespace Core
{
    public class PriceRange
    {
        private double StartingPrice { get; set; }
        private double EndPrice { get; set; }
        public string GetRange() => $"${StartingPrice} - ${EndPrice}";
        public bool IsInRange(double price) => price >= StartingPrice && price <= EndPrice;

        public PriceRange(double startingPrice, double endPrice)
        {
            StartingPrice = startingPrice;
            EndPrice = endPrice;
        }

        public PriceRange(string priceRange)
        {
            var prices = priceRange.Split('-');
            StartingPrice = double.Parse(prices[0].Trim('$', ' '));
            EndPrice = double.Parse(prices[1].Trim('$', ' '));
        }
    }
}
