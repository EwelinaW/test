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
            click(By.XPath("/html/body/div[2]/div/div/div[3]/div/div/ul/li[4]/a"));
            return new LeadsPage(driver);
        }

        public SettingsPage goToSettingsPage()
        {
            click(By.XPath("/html/body/div[2]/div/div/div[3]/div/div[2]/ul/li[2]/a/i"));
            click(By.XPath("/html/body/div[2]/div/div/div[3]/div/div[2]/ul/li[2]/ul/li[3]/a"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => { return d.FindElement(By.Id("profileName")); });

            return new SettingsPage(driver);
        }
    }
}
