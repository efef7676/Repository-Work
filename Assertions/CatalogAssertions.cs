using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure;
using System;

namespace Assertions
{
    public class CatalogAssertions : ObjectAssertions
    {
        protected override string Identifier => "CatalogAssertions";

        public CatalogAssertions(CatalogPage value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<CatalogAssertions> BeExistsInViewedProductsList(Uri expectedImageUri)
        {
            (Subject as CatalogPage)
                .ViewedProductsComponent
                .GetProductBy(expectedImageUri)
                .Should().NotBeNull();

            return new AndConstraint<CatalogAssertions>(this);
        }

    }
}
