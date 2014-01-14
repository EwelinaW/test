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
    class LoginPage : Page
    {
        public LoginPage(IWebDriver driver)
        {
            base.driver = driver;
        }

        public void open()
        {
            open("https://core.futuresimple.com/sales/users/login");
        }

        public DashboardPage logIn(string user, string password)
        {
            insertText(By.Id("user_email"), user);
            insertText(By.Id("user_password"), password);
            click(By.XPath("/html/body/div/form/fieldset/div[3]/div/button"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => { return d.FindElement(By.XPath("/html/body/div[3]/div/div/div/div/header/div/h1")); });

            return new DashboardPage(driver);
        }
    }
}
