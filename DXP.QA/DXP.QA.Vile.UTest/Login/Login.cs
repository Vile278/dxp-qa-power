using DXP.QA.Vile.UTest.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DXP.QA.Vile.UTest.Login
{
    public class Login
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            //Assert.AreEqual(1, 1);
            //driver.Url = "https://paasportal.epimore.com";
            driver.Url = Sites.uRL;
        }
    }
}