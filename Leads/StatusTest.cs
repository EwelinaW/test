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
    class StatusTest : TestBase
    {
        [Test]
        public void shouldSetStatusToNew()
        {
            LoginPage logPage = new LoginPage(driver);
            logPage.open();
            DashboardPage dashPage = logPage.logIn("ewelina.w.witos@gmail.com", "Password1");
            LeadsPage leadsPage = dashPage.goToLeadsPage();
            leadsPage.createLead("Jan", "Marchewka");
            leadsPage.assertLeadCreated("Marchewka");
            leadsPage.assertLeadStatusSet("New");
        }
    }
}
