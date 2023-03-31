using OpenQA.Selenium;
using DXP.QA.Vile.UTest.Helpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using DXP.QA.Vile.UTest.Core;
using OpenQA.Selenium.Interactions;

namespace DXP.QA.Vile.UTest.Models
{
    public class LoginView : ViewBase
    {
        // LoginView
        private readonly string UsernameInputName = "loginfmt";
        private IWebElement UsernameInput => driver.FindElement(By.Name(UsernameInputName));
        private By PasswordInputSelector => By.Name("passwd");
        private IWebElement PasswordInput => driver.FindElement(PasswordInputSelector);
        private By ContinueButtonSelector => By.Id("idSIButton9");
        private IWebElement ADLoginButton => driver.FindElements(By.Id("adLoginButton")).FirstOrDefault();
        private IWebElement ContinueButton => driver.FindElement(ContinueButtonSelector);
        private IWebElement UseAnotherAccountForLogin => driver.FindElement(By.Id("otherTileText"));
        private IWebElement[] AccountTypes => driver.FindElements(By.XPath("//div[text()[contains(.,'Work or school account')]]")).ToArray();

        public bool IsDXPLoginView() => ADLoginButton != null;
        

        public LoginView(IWebDriver driver) : base(driver)
        {
            // Increased timeout in this view since we depend on Azure AD to process our requests.
            Wait = WaitFor(TimeSpan.FromSeconds(30));
            var isLoginView = IsLoginView();
            if (!isLoginView)
            {
                throw new InvalidOperationException("This is not Login view");
            }
        }

        public LoginView ClickADLoginButton()
        {
            Click(ADLoginButton);
            return this;
        }
        public bool IsLoginView()
        {
            var uri = new Uri(driver.Url);
            var isLoginView = uri.Host == "login.microsoftonline.com";
            if (isLoginView)
            {
                // There can be some delay while the page is navigating.
                // Wait for page to load before confirming that it's the login view.
                try
                {
                    WaitForLoginPageLoad();
                }
                catch (Exception)
                {
                    uri = new Uri(driver.Url);
                    isLoginView = uri.Host == "login.microsoftonline.com";
                }
            }

            return isLoginView || driver.Url.ToLower().Contains("/account/login");
        }
        public LoginView EnterUsername(string username)
        {
            WaitForLoginPageLoad();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(UsernameInputName)));
            UsernameInput.SendKeys(username);
            Wait.Until(ExpectedConditions.ElementToBeClickable(ContinueButtonSelector));
            ClickElementPosition(ContinueButton);
            return this;
        }

        public LoginView EnterPassword(string password)
        {
            WaitForLoginPageLoad();
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(PasswordInputSelector));
            }
            catch (WebDriverTimeoutException)
            {
                SelectWorkOrSchoolAccount();
                Wait.Until(ExpectedConditions.ElementToBeClickable(PasswordInputSelector));
            }

            PasswordInput.SendKeys(password);
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("lightbox-cover")));
            WaitForLoginPageLoad();
            if (AccountTypes.Any(x => x.Displayed))
            {
                SelectWorkOrSchoolAccount();
                WaitForLoginPageLoad();
            }
            ClickElementPosition(ContinueButton);
            // vile add
            Wait.Until(ExpectedConditions.ElementToBeClickable(ContinueButtonSelector));
            ClickElementPosition(ContinueButton);
            return this;
        }

        public void WaitForLoginPageLoad()
        {
            driver.WaitForPageReadyState();

            var timeout = DateTime.UtcNow.AddSeconds(15);

            while (true)
            {
                var foundElements = GetVisibleLoginElements();

                var pageLoaded = foundElements.Length > 0;

                foreach (var element in foundElements)
                {
                    try
                    {
                        element.WaitForAnimation();
                    }
                    catch (WebDriverException)
                    {
                        pageLoaded = false;
                    }
                }

                if (pageLoaded) break;

                if (driver.PageSource.Length < 50)
                {
                    // Sometimes we get a blank page from Azure, in this case we need to reload and try again.
                    // Looking like this: <html><head></head><body></body></html>
                    driver.ReloadPage();
                }

                if (DateTime.UtcNow > timeout) throw new InvalidOperationException("Timed out waiting for page to load");
            }

        }
        private IWebElement[] GetVisibleLoginElements()
        {
            var foundElements = new List<IWebElement>();

            try
            {
                foundElements.Add(UsernameInput);
            }
            catch (NoSuchElementException)
            {
            }

            try
            {
                foundElements.Add(PasswordInput);
            }
            catch (NoSuchElementException)
            {
            }

            try
            {
                foundElements.Add(ContinueButton);
            }
            catch (NoSuchElementException)
            {
            }

            try
            {
                foundElements.Add(UseAnotherAccountForLogin);
            }
            catch (NoSuchElementException)
            {
            }

            var accountType = AccountTypes.Where(e =>
            {
                try
                {
                    return e.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }

            }).FirstOrDefault();
            if (accountType != null) foundElements.Add(accountType);

            return foundElements.Where(e =>
            {
                try
                {
                    return e.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }

            }).ToArray();
        }
        private void SelectWorkOrSchoolAccount()
        {
            var workOrSchoolAccountElements = AccountTypes;

            if (workOrSchoolAccountElements == null || !workOrSchoolAccountElements.Any())
            {
                return;
            }

            var element = workOrSchoolAccountElements.First();
            ClickElementPosition(element);
        }
        private void ClickElementPosition(IWebElement element)
        {
            var timeout = TimeProvider.Instance.UtcNow.AddSeconds(25);
            while (true)
            {
                try
                {
                    element.WaitForAnimation(30);
                    driver.ScrollElementIntoView(element);
                    new Actions(driver).MoveToElement(element).Click().Perform();
                    break;
                }
                catch (WebDriverException)
                {
                    if (TimeProvider.Instance.UtcNow > timeout) throw;

                    Thread.Sleep(1000);
                }
            }
        }
    }
}
