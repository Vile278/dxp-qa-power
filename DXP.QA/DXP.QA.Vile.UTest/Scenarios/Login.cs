using DXP.QA.Vile.UTest.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DXP.QA.Vile.UTest.Scenarios
    {
    public class Test
    {
        // App.config
        public const string uRL = "https://paasportal.epimore.com";
        public const string BaseUrl = "https://paasportal.epimore.com/";
        public const string AdminUserName = "uitestadmin@epipaastest.onmicrosoft.com";
        public const string TestUserPassword = "Mozo4445!Th1s";

        // TC 2
        //private const string ProjectName = "vileCmL2903";
        private const string OrgName = "VileOrg10Jan";

        private IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup() 
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() { driver.Dispose();}

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Order(10)]
        public void TestLogin()
        {
            //Assert.AreEqual(1, 1);
            //driver.Url = "https://paasportal.epimore.com";
            driver.Url = uRL;
            //TestSettings testSettings = new TestSettings();
            //var x = TestSettings.PaasTestDomainName; 
            //Console.WriteLine(TestSettings.BaseUrl);
            //driver.Url = TestSettings.BaseUrl;
            LoginView loginView = new LoginView(driver);
            loginView.EnterUsername(AdminUserName);
            loginView.EnterPassword(TestUserPassword);
            //loginView.ClickADLoginButton();
        }
        [Test]
        [Order(20)]
        public void TestSearchProject()
        {
            OrgView orgView= new OrgView(driver);
            orgView.EnterTextSearch(OrgName);
        }
    }
}