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
    class LeadsPage : Page
    {
        public LeadsPage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public void createLead(string firstname, string lastname)
        {
            click(By.LinkText("Lead"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => { return d.FindElement(By.Id("lead-first-name")); });

            insertText(By.Id("lead-first-name"), firstname);
            insertText(By.Id("lead-last-name"), lastname);
            click(By.XPath("/html/body/div[3]/div/div/div/div/div/div/div[2]/a[2]"));

            WebDriverWait waitSaved = new WebDriverWait(driver, TimeSpan.FromSeconds(10));   //wait until lead saved
            waitSaved.Until(d => { return d.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div/header/div/h1/span[3]")); });
        }

        

        public void assertLeadCreated(string lastname)
        {
            //Assert.That(driver.PageSource.Contains(lastname), Is.True);
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div/header/div/h1/span[3]"));   //find lead title
            string text = element.Text;
            Assert.That(text.Contains(lastname));
        }

        public void assertLeadStatusSet(string status)
        {
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/div/ul/div/div/a/span")); //find 'Lead Status' field on page
            string text = element.Text;
            Assert.That(text.Contains(status));
        }


    }
}
