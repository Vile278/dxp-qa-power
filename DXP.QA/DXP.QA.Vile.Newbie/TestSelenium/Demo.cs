using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXP.QA.Vile.Newbie.TestSelenium
{
    [TestFixture]
    public class Demo
    {
        protected IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void StartBrowser()
        {
            //driver = new ChromeDriver("c:\\Source\\vile278\\driver\\chromedriver.exe");
            //driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(false);
        }

        [Test]
        public void Test()
        {
            driver.Url = "https://www.google.com";
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
