using Extensions;
using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class BasePage : DriverUser
    {
        private IWebElement MainLogo => Driver.WaitAndFindElement(By.CssSelector("#header_logo a"));
        private IWebElement CartButton => Driver.WaitAndFindElement(By.CssSelector(".shopping_cart a"));

        public BasePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage ClickOnMainLogo()
        {
            MainLogo.Click();

            return new HomePage(Driver);
        }

        public CartPage ClickOnCart()
        {
            CartButton.Click();

            return new CartPage(Driver);
        }
    }
}
