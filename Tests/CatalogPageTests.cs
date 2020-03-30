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
            var selectedProduct = HomePage.Categories.ClickOnWomen().StandOnProduct(0);

            selectedProduct.GetColorOption(1)
                .Should()
                .Be(selectedProduct.ClickOnColor(1).GetSelectedColor());
        }

        [TestMethod]
        public void ViewedProduct_ShouldExistsInViewedProductsList()
        {
            var productToView = HomePage.Categories.ClickOnWomen()
                .StandOnProduct(0);
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
            var selectedProduct = HomePage.Categories.ClickOnWomen()
                .StandOnProduct(0);
            var expectedImageUri = selectedProduct.GetImageUri();

            (selectedProduct.ClickOnAddToCart(false) as CartPage)
                .Should()
                .BeInCart(expectedImageUri);
        }

        [TestMethod]
        public void WhileMouseIsntOnProduct_AddToCartButtonNotAvailable()
        {
            HomePage.Categories.ClickOnWomen()
                .Products[3]
                .IsAddToCartAvailable
                .Should().BeFalse();
        }

        [TestMethod]
        public void WhileMouseIsOnProduct_AddToCartButtonAvailable()
        {
            HomePage.Categories.ClickOnWomen()
                .StandOnProduct(4)
                .IsAddToCartAvailable
                .Should().BeTrue();
        }

        [TestMethod]
        public void FilterByColor_ShowProductsInSelectedColor()
        {
            var cartPage = HomePage.Categories.ClickOnWomen();
            var selectedColor = cartPage.FilterByColor.GetColorOption(4);

            cartPage
                .FilterByColor.ClickOnColorOption(4)
                .Products
                .Should()
                .AllAreThisColor(selectedColor);
        }//Can't check this - problem with filters in website - not loading.

        [TestMethod]
        public void FilterByPrice_ShowProductsInPriceRange()
        {
            var catalogPage = HomePage.Categories.ClickOnWomen()
                .ChangeFilterPrice(true, true);
            var range = new PriceRange(catalogPage.FilterByPrice.GetPriceRange());

            catalogPage
                .Products
                .Should()
                .AllAreInThisRange(range);
        }//Can't check this - problem with filters in website - not loading.
    }
}
