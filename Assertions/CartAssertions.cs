using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure;
using System;

namespace Assertions
{
    public class CartAssertions : ObjectAssertions
    {
        private CartPage CartPage => Subject as CartPage;
        protected override string Identifier => "CartAssertions";

        public CartAssertions(CartPage value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<CartAssertions> BeInCart(Uri expectedImageUri)
        {
            CartPage
                .GetProduct(expectedImageUri)
                .Should().NotBeNull();

            return new AndConstraint<CartAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<CartAssertions> DeletedSuccessfully(Uri expectedImageUri, int originAmountOfProducts)
        {
            CartPage
                .GetProduct(expectedImageUri)
                .Should().BeNull();

            return new AndConstraint<CartAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<CartAssertions> AmountOfProductsChangedTo(int excpectedAmount)
        {
            if (excpectedAmount > 0)
            {
                CartPage.Products.Count
                    .Should().Be(excpectedAmount);
            }
            else
            {
                CartPage.IsTheCartEmpty
                    .Should().BeTrue();
            }

            return new AndConstraint<CartAssertions>(this);
        }
    }
}
