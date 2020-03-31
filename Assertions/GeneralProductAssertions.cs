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
        public AndConstraint<GeneralProductAssertions> QtyChangedSuccessfully(int expectedQtyValue, double unitPrice)
        {
            ProductRow
                .GetTotalPrice()
                .Should()
                .Be((expectedQtyValue) * unitPrice);

            return new AndConstraint<GeneralProductAssertions>(this);
        }
    }
}
