using OpenQA.Selenium;
using System;

namespace Infrastructure
{
    public abstract class GeneralProduct : BaseComponent
    {
        protected abstract IWebElement Image { get; }
        public virtual Uri GetImageUri() => new Uri(Image.GetAttribute("href"));

        public GeneralProduct(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public virtual DetailsProductPage ClickOnImage()
        {
            Image.Click();

            return new DetailsProductPage(Driver);
        }
    }
}
