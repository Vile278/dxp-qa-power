using DXP.QA.Vile.UTest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXP.QA.Vile.UTest.Models
{
    public abstract class ViewBase
    {
        public IWebDriver driver { get; set; }
        public WebDriverWait Wait { get; set; }
        
        protected ViewBase(IWebDriver driver)
        {
            this.driver = driver;
            Wait = WaitFor(TimeSpan.FromSeconds(30));
        }
        public WebDriverWait WaitFor(TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait;
        }
        protected void Click(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (ElementNotInteractableException)
            {
                driver.ScrollElementIntoView(element);
                element.SafeClick();
            }
            driver.WaitForPageLoad();
        }
    }
}
