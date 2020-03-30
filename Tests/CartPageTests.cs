using Infrastructure;
using FluentAssertions;
using Assertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Tests
{
    [TestClass]
    public class CartPageTests : BaseTest
    {
        [TestMethod]
        public void DeleteProductFromCartWithProducts_WillSuccess()
        {
            var catalogPage = HomePage.Categories.ClickOnWomen().AddNProductsToCart(3);
            var productToAdd = catalogPage.StandOnProduct(6);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);
            var originAmount = currentCartPage.Products.Count;

            currentCartPage
                .DeleteProductBy(expectedImageUri)
                .Should()
                .DeletedSuccessfully(expectedImageUri, originAmount)
                .And
                .AmountOfProductsChangedTo(originAmount-1);
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
                .DeletedSuccessfully(expectedImageUri, originAmount)
                .And
                .AmountOfProductsChangedTo(0);
        }
        [TestMethod]
        public void AddToQtyOfExistsProduct_WillSuccess()
        {
            var productToAdd = HomePage.Categories.ClickOnWomen()
               .StandOnProduct(0);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);
            var productStorage = new ProductRowStorage(currentCartPage.GetProduct(expectedImageUri));

            currentCartPage
                .ChangeQtyInOne(true, expectedImageUri)
                .Should()
                .QtyChangedSuccessfully((int)productStorage.QtyValue+1, productStorage.UnitPrice);
        }

        [TestMethod]
        public void InsertIrrationalNumberToQty_WillFail()
        {
            var productToAdd = HomePage.Categories.ClickOnWomen()
               .StandOnProduct(0);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);
            var productStorage = new ProductRowStorage(currentCartPage.GetProduct(expectedImageUri));

            var productAfterChange = currentCartPage
                .ChangeQtyTo(2.5, expectedImageUri);

            Thread.Sleep(3000); //need to replace with...??

            productAfterChange
                .QtyBox.GetQtyValue()
                .Should()
                .Be(productStorage.QtyValue);
        }

        [TestMethod]
        public void InsertIntegerToQty_WillSuccess()
        {
            var productToAdd = HomePage.Categories.ClickOnWomen()
               .StandOnProduct(0);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);
            var productStorage = new ProductRowStorage(currentCartPage.GetProduct(expectedImageUri));

            currentCartPage
                .ChangeQtyTo(9, expectedImageUri)
                 .Should()
                 .QtyChangedSuccessfully(9, productStorage.UnitPrice);
        }
    }
}
