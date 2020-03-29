using Infrastructure;
using FluentAssertions;
using Assertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CartPageTests : BaseTest
    {
        [TestMethod]
        public void DeleteProductFromCart_WillSuccess()
        {
            HomePage.Categories.ClickOnWomen().AddNProductsToCart(3);
            var productToAdd = HomePage.Categories.ClickOnWomen()
               .StandOnProduct(6);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);
            var originAmount = currentCartPage.Products.Count;

            currentCartPage
                .DeleteProductBy(expectedImageUri)
                .Should()
                .BeDeletedSuccessfully(false, expectedImageUri, originAmount);
        }
        [TestMethod]
        public void DeleteLastProductFromCart_WillSuccess()
        {
            var productToAdd = HomePage.Categories.ClickOnWomen()
               .StandOnProduct(0);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);
            var originAmount = currentCartPage.Products.Count;

            currentCartPage
                .DeleteProductBy(expectedImageUri)
                .Should()
                .BeDeletedSuccessfully(true, expectedImageUri, originAmount);
        }
        [TestMethod]
        public void AddToQtyOfExistsProduct_WillSuccess()
        {
            var productToAdd = HomePage.Categories.ClickOnWomen()
               .StandOnProduct(0);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);
            var productStorage = new ProductRowStorage(currentCartPage.GetProductBy(expectedImageUri));

            currentCartPage
                .ChangeQtyInOne(true, expectedImageUri)
                .Should()
                .BeChangeQtySuccessfully(true, (int)productStorage.QtyValue, productStorage.UnitPrice);
        }

    }
}
