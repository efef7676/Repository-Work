using OpenQA.Selenium;
using Extensions;
using System.Drawing;

namespace Infrastructure
{
    public class DetailsProductPage : BasePage
    {
        private IWebElement SelectedColor => Driver.WaitAndFindElement(By.CssSelector(".attribute_list li .selected"));
        public DetailsProductPage(IWebDriver driver) : base(driver)
        {
        }

        public Color GetSelectedColor() => SelectedColor.GetCssValue("background-color").ConvertToColor();
    }
}
