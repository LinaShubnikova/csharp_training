using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace webAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper FullUserForm(ContactData contact)
        {
            manager.Navigator.GoToUserCreationPage();

            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            //driver.FindElement(By.Name("firstname")).Clear();
            //driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            //driver.FindElement(By.Name("lastname")).Clear();
            //driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToUserCreationPage();
            FullUserForm(contact);
            SubmitUserCreation();
            //LogOut();
            //driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        
        public ContactHelper SubmitUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
       
        public ContactHelper PicUpContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            //driver.FindElement(By.Id("10")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;

        }

        public ContactHelper ModifierContact(ContactData contact)
        {
            
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("nickname"), contact.Nickname);
            //driver.FindElement(By.Name("middlename")).Clear();
            //driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            //driver.FindElement(By.Name("nickname")).Clear();
            //driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            //List<ContactData> contacts = new List<ContactData>();
            //manager.Navigator.GoToHomePage();
            //ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr.center"));
            //foreach (IWebElement element in elements)
            //{
            //    contacts.Add(new ContactData(element.Text));
            //}

            //return contacts;

            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
            int row = 0;
            foreach (IWebElement element in elements)
            {
                if (row > 0)
                {
                    string first = element.FindElement(By.XPath("td[3]")).Text;
                    string second = element.FindElement(By.XPath("td[2]")).Text;
                    contacts.Add(new ContactData(first, second));
                }
                row++;
            }
            return contacts;
        }


    }
}
