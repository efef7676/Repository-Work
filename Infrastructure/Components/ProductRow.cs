using System;
using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class ProductRow : GeneralProduct
    {
        private IWebElement DeleteButton => ParentElement.WaitAndFindElement(By.CssSelector(".cart_delete.text-center a"));
        private IWebElement TotalPrice => ParentElement.WaitAndFindElement(By.CssSelector(".cart_total span"));
        private IWebElement UnitPrice => ParentElement.WaitAndFindElement(By.CssSelector(".cart_unit span span"));
        protected override IWebElement Image => ParentElement.WaitAndFindElement(By.CssSelector(".cart_product a"));
        public QtyBox QtyBox => new QtyBox(Driver, ParentElement.WaitAndFindElement(By.CssSelector(".cart_quantity.text-center")));
        //public override DetailsProductPage ClickOnImage() => base.ClickOnImage();
        public double GetTotalPrice() => double.Parse(TotalPrice.Text.Trim('$'));
        public double GetUnitPrice() => double.Parse(UnitPrice.Text.Trim('$'));

        public ProductRow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CartPage ClickOnDeleteButton()
        {
            DeleteButton.Click();

            return new CartPage(Driver);
        }
    }
}
