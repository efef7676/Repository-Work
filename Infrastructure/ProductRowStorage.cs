namespace Infrastructure
{
    public class ProductRowStorage
    {
        public double TotalPrice { get; set; }
        public double UnitPrice { get; set; }
        public double QtyValue { get; set; }

        public ProductRowStorage(ProductRow product)
        {
            TotalPrice = product.GetTotalPrice();
            UnitPrice = product.GetUnitPrice();
            QtyValue = product.QtyBox.GetQtyValue();

        }
    }
}
