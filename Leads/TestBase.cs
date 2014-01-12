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
    public class TestBase
    {
        public IWebDriver driver;

        [SetUp]
        public void openPage()
        {
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void close()
        {
            driver.Quit();
        }

    }
}
