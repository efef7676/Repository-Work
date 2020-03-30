using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure;

namespace Assertions
{
    public class GeneralProductAssertions : ObjectAssertions
    {
        private ProductRow ProductRow => Subject as ProductRow;
        protected override string Identifier => "GeneralProductAssertions";

        public GeneralProductAssertions(GeneralProduct value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<GeneralProductAssertions> QtyChangedSuccessfully(int expectedQtyValue, double originalPrice)
        {
            ProductRow
                .GetTotalPrice()
                .Should()
                .Be((expectedQtyValue) * originalPrice);

            return new AndConstraint<GeneralProductAssertions>(this);
        }
    }
}
