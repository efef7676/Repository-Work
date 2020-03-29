using System.Linq;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class Categories : BaseComponent
    {
        private IWebElement WomenCategory => ParentElement.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text.ToLower() == "women");
        private IWebElement DressesCategory => ParentElement.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text.ToLower() == "dresses");
        private IWebElement TShirtsCategory => ParentElement.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text.ToLower() == "t-shirts");

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
