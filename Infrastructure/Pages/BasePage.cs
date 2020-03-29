using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class BasePage : DriverUser
    {
        private IWebElement MainLogo => Driver.FindElement(By.CssSelector("#header_logo a"));

        public BasePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage ClickOnMainLogo()
        {
            MainLogo.Click();

            return new HomePage(Driver);
        }
    }
}
