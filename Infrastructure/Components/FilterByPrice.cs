using OpenQA.Selenium;
using System.Linq;
using Extensions;
using OpenQA.Selenium.Interactions;

namespace Infrastructure
{
    public class FilterByPrice : BaseComponent
    {
        private IWebElement PriceRange => ParentElement.WaitAndFindElement(By.CssSelector("#layered_price_range"));
        private IWebElement RaisesTheMinPrice => ParentElement.FindElements(By.CssSelector("#layered_price_slider a"))[0];
        private IWebElement LowerTheMaxPrice => ParentElement.FindElements(By.CssSelector("#layered_price_slider a"))[1];
        private IWebElement ScrollPriceRange => ParentElement.WaitAndFindElement(By.CssSelector(".ui-slider-range.ui-widget-header.ui-corner-all"));
        public string GetPriceRange() => PriceRange.Text;

        public FilterByPrice(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CatalogPage ChangeMinPrice(bool toRaise)
        {
            int width = ScrollPriceRange.Size.Width;
            if (toRaise)
            {
                Driver.ClickByOffest(RaisesTheMinPrice, (width / 15));
            }
            else
            {
                Driver.ClickByOffest(RaisesTheMinPrice, -width / 15);
            }

            return new CatalogPage(Driver);
        }

        public CatalogPage ChangeMaxPrice(bool toLower)
        {
            int width = ScrollPriceRange.Size.Width;
            if (toLower)
            {
                Driver.ClickByOffest(LowerTheMaxPrice, -width / 15);
            }
            else
            {
                Driver.ClickByOffest(LowerTheMaxPrice, width / 15);
            }

            return new CatalogPage(Driver);
        }
    }
}
