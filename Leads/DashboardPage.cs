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
    class DashboardPage : Page
    {
        public DashboardPage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public LeadsPage goToLeadsPage()
        {
            click(By.Id("nav-leads"));
            return new LeadsPage(driver);
        }

    }
}
