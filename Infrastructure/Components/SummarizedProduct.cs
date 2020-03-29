using System;
using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class SummarizedProduct : GeneralProduct
    {
        protected override IWebElement Image => ParentElement.WaitAndFindElement(By.CssSelector("a"));
        private IWebElement Title => ParentElement.WaitAndFindElement(By.CssSelector("h5 a"));
        private IWebElement Description => ParentElement.WaitAndFindElement(By.CssSelector("p .product-description"));

        public SummarizedProduct(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public override Uri GetImageUri() => new Uri(Image.GetAttribute("href"));

        public override DetailsProductPage ClickOnImage()=> base.ClickOnImage();

        public string GetDescription() => Description.Text;

        public DetailsProductPage ClickOnTitle()
        {
            Title.Click();

            return new DetailsProductPage(Driver);
        }
    }
}
