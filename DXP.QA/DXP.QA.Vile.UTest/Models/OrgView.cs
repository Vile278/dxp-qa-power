using DXP.QA.Vile.UTest.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXP.QA.Vile.UTest.Models
{
    public class OrgView : ViewBase
    {
        private const string ProjectName = "vileCmL2903";
        //private const string OrgName = "VileOrg10Jan";

        public OrgView(IWebDriver driver) : base(driver)
        {
        }

        //a[text()="Deployments"]
        private IWebElement ProjectLink => driver.FindElement(By.LinkText(ProjectName));
        private IWebElement SearchOrgField => driver.FindElement(By.Id("SearchTerm"));
        public OrgView EnterTextSearch(string TextSearch)
        {
            var str = "Batki".VietLeMethod();
            driver.WaitForPageLoad();
            
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("SearchTerm")));
            SearchOrgField.SendKeys("abc 123456789 11233333");
            //Wait = WaitFor(TimeSpan.FromSeconds(60));
            //Thread.Sleep(6000); // hạn chế dùng, mất thời gian chạy
            // implicit wait: cũng có 2 mặt: nó áp dụng cho tất cả, và có chỉ văng ra lỗi khi hết thời gian đợi (cho dù không tìm thấy) => như vậy sẽ lâu
            // Explicit wait: áp dụng cho từng cái. Tìm thấy nhưng phải thoản mãn 1 điều kiện nào đó (khác với implicit nhé)
            // Explicit sử dụng thư viện support.ui.ExpectedConditions
            SearchOrgField.Clear();
            SearchOrgField.SendKeys(TextSearch);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(ProjectName)));
            ProjectLink.Click();
            return this;
            
        }
    }
}
