using Core;
using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Assertions
{
    public class ProductListAssertions : ObjectAssertions
    {
        private List<Product> Products => Subject as List<Product>;
        protected override string Identifier => "ProductListAssertions";

        public ProductListAssertions(List<Product> value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<ProductListAssertions> AllAreThisColor(Color expectedColor)
        {
            Products
               .All(product => product.GetAllColorOptions().Contains(expectedColor))
               .Should()
               .BeTrue();

            return new AndConstraint<ProductListAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<ProductListAssertions> AllAreInThisRange(PriceRange priceRange)
        {
            Products
                .All(product => priceRange.IsInRange(product.FocusAProduct().GetPrice()) == true)
                .Should()
                .BeTrue();

            return new AndConstraint<ProductListAssertions>(this);
        }
    }
}
