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
    public class UserHelper : HelperBase
    {
        public UserHelper(ApplicationManager manager) : base(manager)
        {
        }



        public UserHelper FullUserForm(UserData user)
        {
            manager.Navigator.GoToUserCreationPage();

            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(user.Lastname);
            return this;
        }

        
        public UserHelper Create(UserData user)
        {
            manager.Navigator.GoToUserCreationPage();
            FullUserForm(user);
            SubmitUserCreation();
            LogOut();


            //driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        


        
        public UserHelper SubmitUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public UserHelper LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

    }
}
