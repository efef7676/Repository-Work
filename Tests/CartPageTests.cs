using Infrastructure;
using FluentAssertions;
using Assertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System;

namespace Tests
{
    [TestClass]
    public class CartPageTests : BaseTest
    {
        private CartPage _cartPage;
        private Product _productToAdd;
        private Uri _expectedImageUri;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _productToAdd = HomePage.Categories.ClickOnWomen().FocusAProduct(5);
            _expectedImageUri = _productToAdd.GetImageUri();
            _cartPage = (_productToAdd.ClickOnAddToCart(false) as CartPage);

        }

        [TestMethod]
        public void DeleteProductFromCartWithProducts_WillSuccess()
        {
            _cartPage = HomePage.Categories.ClickOnWomen().AddNProductsToCart(3).ClickOnCart();
            var originalAmountOfProducts = _cartPage.Products.Count;

            _cartPage
                .DeleteProduct(_expectedImageUri)
                .Should()
                .DeletedSuccessfully(_expectedImageUri, originalAmountOfProducts)
                .And
                .AmountOfProductsChangedTo(originalAmountOfProducts - 1);
        }

        [TestMethod]
        public void DeleteLastProductFromCart_WillSuccess()
        {
            var originalAmountOfProducts = _cartPage.Products.Count;

            _cartPage
                .DeleteProduct(_expectedImageUri)
                .Should()
                .DeletedSuccessfully(_expectedImageUri, originalAmountOfProducts)
                .And
                .AmountOfProductsChangedTo(0);
        }

        [TestMethod]
        public void AddToQtyOfExistsProduct_WillSuccess()
        {
            var productRowStorage = new ProductRowStorage(_cartPage.GetProduct(_expectedImageUri));

            _cartPage
                .ChangeQtyInOneByClicking(true, _expectedImageUri)
                .Should()
                .ProductQtyChangedSuccessfully((int)productRowStorage.QtyValue + 1, productRowStorage.UnitPrice);
        }

        [TestMethod]
        public void InsertIrrationalNumberToQty_WillFail()
        {
            var productStorage = new ProductRowStorage(_cartPage.GetProduct(_expectedImageUri));
            var productAfterChange = _cartPage.ChangeQtyTo(2.5, _expectedImageUri);

            productAfterChange
                .Should()
                .ProductQtyHasnotChanged((int)productStorage.QtyValue)
                .And
                .ProductPriceDoesntChanged(productStorage.TotalPrice);
        }

        [TestMethod]
        public void InsertIntegerToQty_WillSuccess()
        {
            var productStorage = new ProductRowStorage(_cartPage.GetProduct(_expectedImageUri));

            _cartPage
                .ChangeQtyTo(9, _expectedImageUri)
                 .Should()
                 .ProductQtyChangedSuccessfully(9, productStorage.UnitPrice);
        }
    }
}
