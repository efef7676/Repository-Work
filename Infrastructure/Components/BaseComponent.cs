using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class BaseComponent : DriverUser
    {
        public IWebElement ParentElement { get; set; }

        public BaseComponent(IWebDriver driver, IWebElement parentElement) : base(driver)
        {
            ParentElement = parentElement;
        }
    }
}
