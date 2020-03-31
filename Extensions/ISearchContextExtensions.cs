using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using Core;
using System.Drawing;

namespace Extensions
{
    public static class ISearchContextExtensions
    {

        public static void FocusAnElement(this IWebDriver driver, IWebElement element) =>
            new Actions(driver).MoveToElement(element).Perform();

        public static void ClickByOffest(this IWebDriver driver, IWebElement element, int xOffest) =>
            new Actions(driver).MoveToElement(element).MoveByOffset(xOffest, 0).Click().Perform();

        public static Color GetColorOfElementBackground(this IWebElement element) =>
            element.GetCssValue("background-color").ConvertToColor();

        public static IWebElement WaitAndFindElement(this ISearchContext searchContext, By by)
        {
            var wait = new DefaultWait<ISearchContext>(searchContext);
            wait.Timeout = TimeSpan.FromSeconds(ConfigurationValues.TimeOutWaitSeconds);

            try
            {
                return wait.Until(ctx =>
                {
                    var elem = ctx.FindElement(by);
                    if (elem.Displayed)
                    {
                        return elem;
                    }
                    return null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                if (!searchContext.FindElement(by).Displayed)
                {
                    return null;
                }

                throw;
            }
        }

        public static void WaitUntilElementValueIsEqual(this ISearchContext searchContext, By by, string expectedTextValue)
        {
            var wait = new DefaultWait<ISearchContext>(searchContext);
            wait.Timeout = TimeSpan.FromSeconds(ConfigurationValues.TimeOutWaitSeconds);

            wait.Until(ctx =>
            {
                var elem = ctx.FindElement(by);
                if (elem.GetAttribute("value") == expectedTextValue)
                {
                    return elem;
                }

                return null;
            });
        }

        public static void WaitUntilElementDoesntDiplayed(this ISearchContext searchContext, By by)
        {
            var wait = new DefaultWait<ISearchContext>(searchContext);
            wait.Timeout = TimeSpan.FromSeconds(ConfigurationValues.TimeOutWaitSeconds);

            wait.Until(ctx =>
            {
                try
                {
                    return !(ctx.FindElement(by).Displayed);
                }
                catch (Exception exception)
                {
                    if (exception is StaleElementReferenceException || exception is NoSuchElementException)
                    {
                        return true;
                    }

                    throw;
                }
            });
        }
    }
}
