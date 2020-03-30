using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Extensions;
using OpenQA.Selenium.Interactions;

namespace Infrastructure
{
    public class CartPage : BasePage, IHasProducts<ProductRow>
    {
        public List<ProductRow> Products
        {
            get
            {
                var elements = Driver.FindElements(By.CssSelector("#cart_summary tbody tr"));
                return elements.Count == 0 ? new List<ProductRow>() : elements.Select(s => new ProductRow(Driver, s)).ToList();
            }
        }

        public ProductRow GetProduct(Uri imageUri) => Products.FirstOrDefault(p => p.GetImageUri() == imageUri);

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public CartPage DeleteProductBy(Uri imageUri)
        {
            GetProduct(imageUri).ClickOnDeleteButton();
            Driver.WaitUntilElementDoesntDiplayed(By.CssSelector($"tbody a[href='{imageUri}']"));

            return new CartPage(Driver);
        }

        public ProductRow ChangeQtyInOne(bool RaiseQty, Uri imageUri)
        {
            var currentProduct = GetProduct(imageUri);
            var newQty = currentProduct.QtyBox.GetQtyValue();

            if (RaiseQty)
            {
                newQty += 1;
                currentProduct.QtyBox.ClickOnUpButton();
            }
            else if(!RaiseQty && newQty > 1)
            {
                newQty -= 1;
                currentProduct.QtyBox.ClickDownUpButton();
            }

            currentProduct
                .QtyBox
                .ParentElement
                .WaitUntilElementValueIsEqual(By.CssSelector("input"), $"{newQty}");

            return currentProduct;
        }

        public ProductRow ChangeQtyTo(double changeTo, Uri imageUri)
        {
            var currentProduct = GetProduct(imageUri);
            var originQty = currentProduct.QtyBox.GetQtyValue();

            currentProduct.QtyBox.ChangeQty(changeTo);
            if ((int)changeTo == changeTo)
            {
                currentProduct
                    .QtyBox
                    .ParentElement
                    .WaitUntilElementValueIsEqual(By.CssSelector("input"), $"{changeTo}");
            }else
            {
                new Actions(Driver).DoubleClick(currentProduct.ParentElement.FindElement(By.CssSelector(".cart_total"))).Perform();
            }

            return currentProduct;
        }
    }
}
