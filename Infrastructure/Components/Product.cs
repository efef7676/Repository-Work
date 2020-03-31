using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Extensions;

namespace Infrastructure
{
    public class Product : GeneralProduct
    {
        private List<IWebElement> ColorOptions => ParentElement.FindElements(By.CssSelector(".color_to_pick_list.clearfix li a")).ToList();
        private IWebElement AddToCartButton => ParentElement.WaitAndFindElement(By.CssSelector(".right-block .button-container .button.ajax_add_to_cart_button.btn.btn-default"));
        private IWebElement Price => ParentElement.WaitAndFindElement(By.CssSelector(".content_price .price.product-price"));
        private IWebElement Name => ParentElement.WaitAndFindElement(By.CssSelector(".right-block .product-name"));
        protected override IWebElement Image => ParentElement.WaitAndFindElement(By.CssSelector(".product-image-container .product_img_link"));
        public bool IsAddToCartAvailable => ParentElement.WaitAndFindElement(By.CssSelector(".right-block .button-container .button.ajax_add_to_cart_button.btn.btn-default span")) == null ? false : true;
        public double GetPrice() => double.Parse(Price.Text.Trim('$'));
        public List<Color> GetAllColorOptions() => ColorOptions.Select(s => s.GetColorOfElement()).ToList();
        public Color GetColorOption(int index = 0) => ColorOptions[index].GetColorOfElement();

        public Product(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public Product FocusAProduct()
        {
            Driver.FocusAnElement(ParentElement.WaitAndFindElement(By.CssSelector(".left-block .product-image-container")));

            return this;
        }

        public DetailsProductPage ClickOnColorOption(int index = 0)
        {
            ColorOptions[index].Click();

            return new DetailsProductPage(Driver);
        }

        public DetailsProductPage ClickOnName()
        {
            Name.Click();

            return new DetailsProductPage(Driver);
        }

        public BasePage ClickOnAddToCart(bool ContinueShopping = true)
        {
            AddToCartButton.Click();
            if (ContinueShopping)
            {
                Driver.WaitAndFindElement(By.CssSelector("#layer_cart .continue.btn.btn-default.button.exclusive-medium")).Click();
                Driver.WaitUntilElementDoesntDiplayed(By.CssSelector("#layer_cart"));

                return new CatalogPage(Driver);
            }

            Driver.WaitAndFindElement(By.CssSelector("#layer_cart .btn.btn-default.button.button-medium")).Click();
            Driver.WaitUntilElementDoesntDiplayed(By.CssSelector("#layer_cart"));

            return new CartPage(Driver);
        }

    }
}
