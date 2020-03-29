using Infrastructure;
using System.Collections.Generic;

namespace Assertions
{
    public static class AssertionsExtensions
    {
        public static CatalogAssertions Should(this CatalogPage instance) => new CatalogAssertions(instance);

        public static CartAssertions Should(this CartPage instance) => new CartAssertions(instance);

        public static GeneralProductAssertions Should(this GeneralProduct instance) => new GeneralProductAssertions(instance);

        public static ProductListAssertions Should(this List<Product> instance) => new ProductListAssertions(instance);
    }
}
