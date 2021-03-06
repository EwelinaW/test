﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;


namespace Leads
{
    class LeadTest : TestBase
    {
        [Test]
        public void shouldCreateLead()
        {
            LoginPage logPage = new LoginPage(driver);
            logPage.open();
            DashboardPage dashPage = logPage.logIn("ewelina.w.witos@gmail.com", "Password1");
            LeadsPage leadsPage = dashPage.goToLeadsPage();
            leadsPage.createLead("Marek", "Lewarek");
            leadsPage.assertLeadCreated("Lewarek");
        }
    }
}
