using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;


namespace Extensions
{
    public static class ISearchContextExtensions
    {
        public static IWebElement WaitAndFindElement(this ISearchContext iSearchContext, By by)
        {
            try
            {
                var wait = new DefaultWait<ISearchContext>(iSearchContext);
                wait.Timeout = TimeSpan.FromSeconds(15);
                return wait.Until(ctx =>
                {
                    var elem = ctx.FindElement(by);
                    wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                    if (!elem.Enabled || !elem.Displayed)
                    {
                        return null;
                    }

                    return elem;
                });
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        public static void WaitUntilElementIs(this ISearchContext iSearchContext, By by, string expectedTextValue)
        {
            var wait = new DefaultWait<ISearchContext>(iSearchContext);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.Until(ctx =>
            {
                var elem = ctx.FindElement(by);
                if (!elem.Enabled || !elem.Displayed)
                    return null;
                if (elem.GetAttribute("value") == expectedTextValue)
                    return elem;

                return null;
            });
        }

        public static void WaitUntilElementDoesntExists(this ISearchContext iSearchContext, By by)
        {
            var wait = new DefaultWait<ISearchContext>(iSearchContext);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.Until(p =>
            {
                try
                {
                    return !(p.FindElement(by).Enabled);
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }

        public static void StandOn(this ISearchContext searchContext, IWebDriver driver, By by) =>
            new Actions(driver).MoveToElement(searchContext.WaitAndFindElement(by)).Perform();
    }
}
