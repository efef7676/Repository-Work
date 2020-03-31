using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Drawing;
using Extensions;

namespace Infrastructure
{
    public class FilterByColor : BaseComponent
    {
        private List<IWebElement> ColorOptionsToFilter => ParentElement.FindElements(By.CssSelector("#ul_layered_id_attribute_group_3 li")).ToList();
        public Color GetColorOption(int index = 0) => ColorOptionsToFilter[index].WaitAndFindElement(By.CssSelector("input")).GetColorOfElementBackground();

        public FilterByColor(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CatalogPage ClickOnColorOption(int index = 0)
        {
            ColorOptionsToFilter[index].FindElement(By.CssSelector("label a")).Click();

            return  new CatalogPage(Driver);
        }
    }
}
