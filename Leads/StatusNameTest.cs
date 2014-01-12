using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;


namespace Leads
{
    class StatusNameTest : TestBase
    {
        [Test]
        public void shouldChangeLeadStatusName()
        {
            LoginPage logPage = new LoginPage(driver);
            logPage.open();
            DashboardPage dashPage = logPage.logIn("ewelina.w.witos@gmail.com", "TelAviv2013");
            SettingsPage setPage = dashPage.goToSettingsPage();
            setPage.changeLeadsStatusName("Submitted");
            setPage.assertLeadStatusNameChanged("Submitted");
        }
    }
}
