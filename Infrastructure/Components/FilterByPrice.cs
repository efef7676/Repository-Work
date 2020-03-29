using OpenQA.Selenium;
using System.Linq;
using Extensions;
using OpenQA.Selenium.Interactions;

namespace Infrastructure
{
    public class FilterByPrice : BaseComponent
    {
        private IWebElement PriceRange => ParentElement.WaitAndFindElement(By.CssSelector("#layered_price_range"));
        private IWebElement RaisesTheMinPrice => ParentElement.FindElements(By.CssSelector("#layered_price_slider a")).FirstOrDefault();
        private IWebElement ScrollPriceRange => ParentElement.WaitAndFindElement(By.CssSelector(".ui-slider-range.ui-widget-header.ui-corner-all"));

        public FilterByPrice(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public string GetPriceRange() => PriceRange.Text;

        public void ChangeFilterPrice(bool toRaiseTheMin)
        {
            int width = ScrollPriceRange.Size.Width;
            Actions act = new Actions(Driver);
            if (toRaiseTheMin)
            {
                act.MoveToElement(RaisesTheMinPrice).MoveByOffset((width / 3) - 10, 0).Click().Perform();
            }else
            {
                act.MoveToElement(ScrollPriceRange).MoveByOffset((width / 3)+10, 0).Click().Perform();
            }
        }
    }
}
