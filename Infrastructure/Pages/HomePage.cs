using Extensions;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class HomePage : BasePage
    {
        public Categories Categories => new Categories(Driver, Driver.WaitAndFindElement(By.CssSelector("#block_top_menu ul")));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
    }
}
