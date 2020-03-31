using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Infrastructure;
using Assertions;
using System.Linq;
using Core;

namespace Tests
{
    [TestClass]
    public class CatalogPageTests : BaseTest
    {
        [TestMethod]
        public void SelectProductByColor_ShowTheProductWithThisColor()
        {
            var selectedProduct = HomePage.Categories.ClickOnWomen().FocusAProduct(0);

            selectedProduct.GetColorOption(1)
                .Should()
                .Be(selectedProduct.ClickOnColorOption(1).GetSelectedColor());
        }

        [TestMethod]
        public void ViewedProduct_ShouldExistsInViewedProductsList()
        {
            var productToView = HomePage.Categories.ClickOnWomen().FocusAProduct(0);
            var expectedImageUri = productToView.GetImageUri();

            productToView.ClickOnName()
                .ClickOnMainLogo()
                 .Categories.ClickOnWomen()
                 .Should()
                 .BeInViewedProductsList(expectedImageUri);
        }
        [TestMethod]
        public void AddProductToCart_ThisProductExistsInCart()
        {
            var selectedProduct = HomePage.Categories.ClickOnWomen().FocusAProduct(0);
            var expectedImageUri = selectedProduct.GetImageUri();

            (selectedProduct.ClickOnAddToCart(false) as CartPage)
                .Should()
                .BeInCart(expectedImageUri);
        }

        [TestMethod]
        public void WhileMouseIsntOnProduct_AddToCartButtonNotAvailable()
        {
            HomePage.Categories.ClickOnWomen()
                .NotStandingOnProducts()
                .Products[3]
                .IsAddToCartAvailable
                .Should().BeFalse();
        }

        [TestMethod]
        public void WhileMouseIsOnProduct_AddToCartButtonAvailable()
        {
            HomePage.Categories.ClickOnWomen()
                .FocusAProduct(4)
                .IsAddToCartAvailable
                .Should().BeTrue();
        }

        [TestMethod]
        public void FilterByColor_ShowProductsInSelectedColor()
        {
            var cartPage = HomePage.Categories.ClickOnWomen();
            var selectedColor = cartPage.FilterByColor.GetColorOption(4);

            cartPage
                .ClickOnColorOptionToFilter(4)
                .Products
                .Should()
                .AllAreThisColor(selectedColor);
        }//Can't check this - problem with filters in website - not loading.

        [TestMethod]
        public void FilterByPrice_ShowProductsInPriceRange()
        {
            var catalogPage = HomePage.Categories.ClickOnWomen()
                .ChangeMaxPriceFilter(true).ChangeMinPriceFilter(true);
            var range = new PriceRange(catalogPage.FilterByPrice.GetPriceRange());

            catalogPage
                .Products
                .Should()
                .AllAreInThisRange(range);
        }//Can't check this - problem with filters in website - not loading.

        [TestMethod]
        public void FilterByPriceAndColor_ShowProductsInPriceRangeAndInSelectedColor()
        {
            var catalogPage = HomePage.Categories.ClickOnWomen();
            var colorToSelect = catalogPage.FilterByColor.GetColorOption(3);
            catalogPage = catalogPage.ChangeMaxPriceFilter(true).ChangeMinPriceFilter(true);
            var range = new PriceRange(catalogPage.FilterByPrice.GetPriceRange());

            catalogPage
                .Products
                .Should()
                .AllAreInThisRange(range)
                .And
                .AllAreThisColor(colorToSelect);
        }//Can't check this - problem with filters in website - not loading.
    }
}
