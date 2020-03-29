using OpenQA.Selenium;
using System;

namespace Infrastructure
{
    public abstract class GeneralProduct : BaseComponent
    {
        protected abstract IWebElement Image { get; }

        public GeneralProduct(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public abstract Uri GetImageUri();

        public virtual DetailsProductPage ClickOnImage()
        {
            Image.Click();

            return new DetailsProductPage(Driver);
        }
    }
}
