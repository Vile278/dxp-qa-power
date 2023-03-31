using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DXP.QA.Vile.UTest.Core;

namespace DXP.QA.Vile.UTest.Helpers
{
    public static class WebDriverHelpers
    {
        // Helper: WebDriverHelpers.cs
        public static void WaitForPageLoad(this IWebDriver driver)
        {
            WaitForPageReadyState(driver);
            WaitForAjaxComplete(driver);
        }

        public static string VietLeMethod(this string str)
        {
            return "vietle_" + str;
        }

        public static void WaitForPageReadyState(this IWebDriver driver, string state = "complete")
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(webDriver => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals(state));
        }
        public static void WaitForAjaxComplete(this IWebDriver driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(webDriver => (long)((IJavaScriptExecutor)webDriver).ExecuteScript("if (typeof $ !== 'undefined') return $.active; else return 0;") == 0);
        }
        public static void ThrowIfStaleElement(this IWebElement element)
        {
            // This enabled-check will throw an exception if element is stale
            var enabled = element.Enabled;
        }
        public static void SafeClick(this IWebElement element)
        {
            element.WaitForAnimation();
            element.Click();
        }
        public static void WaitForAnimation(this IWebElement element, int timeoutSeconds = 5)
        {
            var timeout = TimeProvider.Instance.UtcNow.AddSeconds(timeoutSeconds);
            var location = new Point();
            var size = new Size();
            int samePositionCount = 0;
            while (samePositionCount < 2)
            {
                if (TimeProvider.Instance.UtcNow > timeout) throw new TimeoutException("Animation did not complete in time.");

                var currentLocation = element.Location;
                var currentSize = element.Size;

                if (currentLocation == location && currentSize == size && element.Displayed)
                {
                    samePositionCount++;
                }
                else
                {
                    samePositionCount = 0;
                    location = currentLocation;
                    size = currentSize;
                }

                Thread.Sleep(50);
            }
        }
        public static void ReloadPage(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
            WaitForPageLoad(driver);
        }
        public static IWebElement ScrollElementIntoView(this IWebDriver driver, IWebElement element, int pixelToScrollDown = -50)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            driver.WaitForPageLoad();

            try
            {
                // scrolling into view plus additional offset for the navbar height
                ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].scrollIntoView(true); window.scrollBy(0, {pixelToScrollDown});", element);
                return element;
            }
            catch (WebDriverException)
            {
                // Exception happens sometimes:
                // WebDriverException: javascript error: Cannot read property 'scrollIntoView' of null

                // It seems this can happen when the element has become stale after sending it to the javascript.
                // Throw StaleElementException instead of WebDriverException if this is the case.
                element.ThrowIfStaleElement();
                throw;
            }
        }
    }
}
