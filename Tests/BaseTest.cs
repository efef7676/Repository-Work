using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        protected HomePage HomePage;
        private IWebDriver _driver;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.Manage().Window.Maximize();
            HomePage = new HomePage(_driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Close();
        }
    }
}
