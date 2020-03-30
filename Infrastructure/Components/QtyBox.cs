using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class QtyBox : BaseComponent
    {
        private IWebElement QtyValueInputBox => ParentElement.FindElement(By.CssSelector(".cart_quantity_input.form-control.grey"));
        private IWebElement QtyValue => ParentElement.FindElement(By.CssSelector("input"));
        private IWebElement DownButton => ParentElement.WaitAndFindElement(By.CssSelector(".cart_quantity_down.btn.btn-default.button-minus"));
        private IWebElement UpButton => ParentElement.WaitAndFindElement(By.CssSelector(".cart_quantity_up.btn.btn-default.button-plus"));
        public double GetQtyValue() => double.Parse(QtyValue.GetAttribute("value"));

        public QtyBox(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }


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
            QtyValueInputBox.Clear();
            QtyValueInputBox.SendKeys($"{number}");

            return new CartPage(Driver);
        }
    }
}
