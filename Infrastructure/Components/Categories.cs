using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Infrastructure
{
    public class Categories : BaseComponent
    {
        private IWebElement GeneralCategory(string categoryName) => ParentElement.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text.ToLower() == categoryName);
        private IWebElement WomenCategory => GeneralCategory("women");
        private IWebElement DressesCategory => GeneralCategory("dresses");
        private IWebElement TShirtsCategory => GeneralCategory("t-shirts");

        public Categories(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CatalogPage ClickOnWomen()
        {
            WomenCategory.Click();

            return new CatalogPage(Driver);
        }
    }
}
