using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace webAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();

            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));

            // переносимые строки метода ниже

            //FirefoxOptions options = new FirefoxOptions();
            //options.UseLegacyImplementation = true;
            //options.BrowserExecutableLocation = @"D:\firefox\firefox 52\firefox.exe";
            //driver = new FirefoxDriver(options);
            //baseURL = "http://localhost/";
            //verificationErrors = new StringBuilder();

            //loginHelper = new LoginHelper(driver);
            //navigator = new NavigationHelper(driver, baseURL);
            //groupHelper = new GroupHelper(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }

        //protected void GoToUserCreationPage()
        //{
        //    driver.FindElement(By.LinkText("add new")).Click();
        //}

        //protected void FullUserForm(ContactData user)
        //{
        //    driver.FindElement(By.Name("firstname")).Clear();
        //    driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
        //    driver.FindElement(By.Name("lastname")).Clear();
        //    driver.FindElement(By.Name("lastname")).SendKeys(user.Lastname);
        //}

        //protected void SubmitUserCreation()
        //{
        //    driver.FindElement(By.Name("submit")).Click();
        //}

        //protected void LogOut()
        //{
        //    driver.FindElement(By.LinkText("Logout")).Click();
        //}

        //private bool IsElementPresent(By by)
        //{
        //    try
        //    {
        //        driver.FindElement(by);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}
    }
}
