using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Drawing;
using Extensions;

namespace Infrastructure
{
    public class FilterByColor : BaseComponent
    {
        private List<IWebElement> Colors => ParentElement.FindElements(By.CssSelector("#ul_layered_id_attribute_group_3 li")).ToList();

        public FilterByColor(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CatalogPage ClickOnColor(int index = 0)
        {
            Colors[index].FindElement(By.CssSelector("label a")).Click();

            return new CatalogPage(Driver);
        }
        public Color GetColor(int index = 0) => Colors[index].WaitAndFindElement(By.CssSelector("input")).GetCssValue("background-color").ConvertToColor();

    }
}
