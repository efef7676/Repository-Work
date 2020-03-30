using OpenQA.Selenium;
using Extensions;
using System.Drawing;

namespace Infrastructure
{
    public class DetailsProductPage : BasePage
    {
        private IWebElement SelectedColor => Driver.WaitAndFindElement(By.CssSelector(".attribute_list li .selected"));
        public Color GetSelectedColor() => SelectedColor.GetColorOfElement();

        public DetailsProductPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
