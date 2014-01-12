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
    class LoginTest : TestBase
    {
        [Test]
        public void shouldLoginToApp()
        {
            LoginPage logPage = new LoginPage(driver);
            logPage.open();
            logPage.logIn("ewelina.w.witos@gmail.com", "Password1");
            logPage.assertTextPresent("Dashboard");
        }
    }
}
