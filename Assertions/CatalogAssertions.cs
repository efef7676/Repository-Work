using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure;
using System;

namespace Assertions
{
    public class CatalogAssertions : ObjectAssertions
    {
        private CatalogPage CatalogPage => Subject as CatalogPage;
        protected override string Identifier => "CatalogAssertions";

        public CatalogAssertions(CatalogPage value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<CatalogAssertions> BeInViewedProductsList(Uri expectedImageUri)
        {
            CatalogPage
                .ViewedProductsComponent
                .GetProduct(expectedImageUri)
                .Should().NotBeNull();

            return new AndConstraint<CatalogAssertions>(this);
        }

    }
}
