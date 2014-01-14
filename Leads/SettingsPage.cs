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

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => { return d.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div[2]/div[2]/div/div[2]/div[3]/div/div/div/div/div/button")); });

            click(By.XPath("/html/body/div[3]/div/div[2]/div[2]/div[2]/div/div[2]/div[3]/div/div/div/div/div/button")); // edit button

            clearText(By.CssSelector("div.named-objects-list.ui-sortable > div > div.item.form > form > fieldset > div.control-group > div.controls > #name"));
            insertText(By.CssSelector("div.named-objects-list.ui-sortable > div > div.item.form > form > fieldset > div.control-group > div.controls > #name"), newname);
            click(By.XPath("//div[@id='lead-status']/div/div/div/form/fieldset/div[3]/div/button"));
        }
    }
}
