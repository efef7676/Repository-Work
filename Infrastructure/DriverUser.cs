using OpenQA.Selenium;
using System;

namespace Infrastructure
{
    public abstract class DriverUser
    {
        protected IWebDriver Driver { get; set; }
        public DriverUser(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
