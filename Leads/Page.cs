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
    class Page
    {
        public IWebDriver driver;

        public void open(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void click(By by)
        {
            IWebElement element = driver.FindElement(by);
            element.Click();
        }

        public void insertText(By by, string text)
        {
            IWebElement element = driver.FindElement(by);
            element.SendKeys(text);
        }

        public void clearText(By by)
        {
            IWebElement element = driver.FindElement(by);
            element.Clear();
        }

        public void assertTextPresent(string text)
        {
            Assert.That(driver.PageSource.Contains(text), Is.True);
        }

        public void assertTitle(string title)
        {
            Assert.That(driver.Title.Contains(title), Is.True);
        }

        public LoginPage logOut()
        {
            click(By.CssSelector("i.icon-cogs"));
            click(By.LinkText("Logout"));
            return new LoginPage(driver);
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
