using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Leads
{
    class SettingsChangeTest : TestBase
    {
        [Test]
        public void shouldChangeLeadStatusName()
        {
            LoginPage logPage = new LoginPage(driver);
            logPage.open();
            DashboardPage dashPage = logPage.logIn("ewelina.w.witos@gmail.com", "Password1");
            SettingsPage setPage = dashPage.goToSettingsPage();
            setPage.changeLeadsStatusName("Submitted");
            
            logPage = setPage.logOut();
            logPage.open();
            dashPage = logPage.logIn("ewelina.w.witos@gmail.com", "Password1");
            LeadsPage leadPage = dashPage.goToLeadsPage();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => { return d.FindElement(By.LinkText("A BumBum")); });

            leadPage.click(By.LinkText("A BumBum"));

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(d => { return d.FindElement(By.CssSelector("span.lead-status")); });

            IWebElement element = driver.FindElement(By.CssSelector("span.lead-status"));
            string text = element.Text;
            Assert.That(text.Contains("Submitted"));
        }
    }
}
