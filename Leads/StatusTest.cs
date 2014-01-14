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
    class StatusTest : TestBase
    {
        [SetUp]
        public void SettingStatusName()
        {
            LoginPage logPage = new LoginPage(driver);
            logPage.open();
            DashboardPage dashPage = logPage.logIn("ewelina.w.witos@gmail.com", "Password1");
            SettingsPage setPage = dashPage.goToSettingsPage();
            setPage.changeLeadsStatusName("New");
            setPage.logOut();
        }

        [Test]
        public void shouldSetStatusToNew()
        {
            LoginPage logPage = new LoginPage(driver);
            logPage.open();
            DashboardPage dashPage = logPage.logIn("ewelina.w.witos@gmail.com", "Password1");
            LeadsPage leadsPage = dashPage.goToLeadsPage();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => { return d.FindElement(By.LinkText("Lead")); });

            leadsPage.createLead("King", "Kong");
            leadsPage.assertLeadCreated("Kong");
            leadsPage.assertLeadStatusSet("New");
        }
    }
}
