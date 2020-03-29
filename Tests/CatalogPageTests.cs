using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Infrastructure;
using Assertions;

namespace Tests
{
    [TestClass]
    public class CatalogPageTests : BaseTest
    {
        [TestMethod]
        public void SelectProductByColor_ShowTheProductWithThisColor()
        {
            var selectedProduct = HomePage.Categories.ClickOnWomen().StandOnProduct(0);

            selectedProduct.GetColor(1)
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
                 .BeExistsInViewedProductsList(expectedImageUri);
        }
        [TestMethod]
        public void AddProductToCart_ThisProductExistsInCart()
        {
            var selectedProduct = HomePage.Categories.ClickOnWomen()
                .StandOnProduct(0);
            var expectedImageUri = selectedProduct.GetImageUri();

            (selectedProduct.ClickOnAddToCart(false) as CartPage)
                .Should()
                .BeExistsInCart(expectedImageUri);
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
            var selectedColor = cartPage.FilterByColor.GetColor(4);

            cartPage
                .FilterByColor.ClickOnColor(4)
                .Products
                .Should()
                .BeBySelectedColor(selectedColor);
        }//Can't check this - problem with filters in website - not loading.
    }
}
