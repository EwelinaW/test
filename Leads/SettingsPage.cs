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
    class SettingsPage : Page
    {
        public SettingsPage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public void changeLeadsStatusName(string newname)
        {
            click(By.XPath("/html/body/div[3]/div/div[2]/div[2]/div/ul/li[9]/a"));  //Leads on menu
            click(By.XPath("/html/body/div[3]/div/div[2]/div[2]/div[2]/div/ul/li[2]/a"));   //Lead statuses
            click(By.XPath("/html/body/div[3]/div/div[2]/div[2]/div[2]/div/div[2]/div[3]/div/div/div/div/div/button")); //first status edit button
            insertText(By.Id("name"), newname + Keys.Enter);

            click(By.XPath("/html/body/div[3]/div/div[2]/div[2]/div[2]/div/div[2]/div[3]/div/div/div/form/fieldset/div[3]/div/button"));

        }

        public void assertLeadStatusNameChanged(string newname)
        {
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div[2]/div[2]/div/div[2]/div[3]/div/div/div/label/h4")); //find Statuses list on page
            string text = element.Text;
            Assert.That(text.Contains(newname));
        }

    }
}
