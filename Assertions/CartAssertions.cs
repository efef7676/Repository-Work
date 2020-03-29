using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure;
using System;

namespace Assertions
{
    public class CartAssertions : ObjectAssertions
    {
        protected override string Identifier => "CartAssertions";

        public CartAssertions(CartPage value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<CartAssertions> BeExistsInCart(Uri expectedImageUri)
        {
            (Subject as CartPage)
                .GetProductBy(expectedImageUri)
                .Should().NotBeNull();

            return new AndConstraint<CartAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<CartAssertions> BeDeletedSuccessfully(bool isLastProduct, Uri expectedImageUri, int originAmountOfProducts)
        {
            if (isLastProduct)
            {
                (Subject as CartPage)
                    .GetProductBy(expectedImageUri)
                    .Should().BeNull();
                (Subject as CartPage).Products.Count
                    .Should().Be(0);
            }
            else
            {
                (Subject as CartPage)
                    .GetProductBy(expectedImageUri)
                    .Should().BeNull();
                (Subject as CartPage).Products.Count
                    .Should().Be(originAmountOfProducts-1);
            }

            return new AndConstraint<CartAssertions>(this);
        }
    }
}
