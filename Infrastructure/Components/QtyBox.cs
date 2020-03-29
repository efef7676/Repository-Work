using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class QtyBox : BaseComponent
    {
        private IWebElement QtyValue => ParentElement.WaitAndFindElement(By.CssSelector(".cart_quantity_input.form-control.grey"));
        private IWebElement DownButton => ParentElement.WaitAndFindElement(By.CssSelector(".cart_quantity_down.btn.btn-default.button-minus"));
        private IWebElement UpButton => ParentElement.WaitAndFindElement(By.CssSelector(".cart_quantity_up.btn.btn-default.button-plus"));

        public QtyBox(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public double GetQtyValue() => double.Parse(QtyValue.GetAttribute("value"));

        public CartPage ClickOnUpButton()
        {
            UpButton.Click();

            return new CartPage(Driver);
        }

        public CartPage ClickDownUpButton()
        {
            DownButton.Click();

            return new CartPage(Driver);
        }

        public CartPage ChangeQty(double number)
        {
            QtyValue.Clear();
            QtyValue.SendKeys($"{number}");

            return new CartPage(Driver);
        }
    }
}
