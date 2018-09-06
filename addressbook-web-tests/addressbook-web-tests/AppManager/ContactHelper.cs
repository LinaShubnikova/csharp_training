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
using System.Text.RegularExpressions;

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
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            //Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            //Type(By.Name("homepage"), contact.Homepage);
            //Type(By.Name("notes"), contact.Notes);
            return this;
        }

        /*internal ContactData GetContactDetailInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModificationLic(0);
            return new ContactData(firstName, lastName)
            {
                AllData = allData,
            };
        }*/

        public string GetContactDetailInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModificationLic2(0);
            return driver.FindElement(By.Id("content")).Text;
            //return new ContactData(firstName, lastName)
            //{
            //    AllData = allData,
            //};
        }

        // информация о контакте со страницы заполнения формы контакта
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModificationLic(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            //string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            //string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            //string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                //Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                //Homepage = homepage,
                //Notes = notes
            };
        }

        // информация о контакте с главной страницы
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail,

            };
        }

        public void InitContactModificationLic2(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public void InitContactModificationLic(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        internal int GetContactCount()
        {
            //return driver.FindElements(By.CssSelector("tr.entry")).Count; // находим количество элементов (то есть контактов) в классе tr
            //return driver.FindElements(By.CssSelector("tr")).Count;
            return driver.FindElements(By.XPath(".//*[@id='maintable']/tbody/tr/td[3]")).Count;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToUserCreationPage();
            FullUserForm(contact);
            SubmitUserCreation();
            ReturnToHomePage();
            //LogOut();
            //driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper DriverAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper ContactDelete(int l)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(l);
            PicUpContact();
            //DriverAlert();
            return this;
        }

        public ContactHelper SubmitUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
       
        public ContactHelper PicUpContact()
        {
            //driver.FindElement(By.Name("selected[]")).Click();
            //driver.FindElement(By.Id("10")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;

        }

        //public ContactHelper ModifierContact(ContactData contact)
        //{

        //    driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
        //    Type(By.Name("middlename"), contact.Middlename);
        //    Type(By.Name("nickname"), contact.Nickname);
        //    //driver.FindElement(By.Name("middlename")).Clear();
        //    //driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
        //    //driver.FindElement(By.Name("nickname")).Clear();
        //    //driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
        //    driver.FindElement(By.Name("update")).Click();
        //    return this;
        //}

        public ContactHelper ModifierContact(int p, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("nickname"), contact.Nickname);
            //InitContactModification(p);
            //FullUserForm(contact);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                //List<ContactData> contacts = new List<ContactData>();
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
                int row = 0;
                foreach (IWebElement element in elements)
                {
                    if (row > 0)
                    {
                        string Firstname = element.FindElement(By.XPath("td[3]")).Text;
                        string Lastname = element.FindElement(By.XPath("td[2]")).Text;
                        contactCache.Add(new ContactData(Firstname, Lastname));
                    }
                    row++;
                }
            }
            return new List<ContactData>(contactCache);
        }


        public ContactHelper InitContactsCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (v+1) + "]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int t)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + t + "]")).Click();
            return this;
        }


        public ContactHelper SubmitContactModification()
        {
            //driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        // метод взятия количества контактов
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            // берем строку, в которой содержится количество контактов на странице
            string text =  driver.FindElement(By.TagName("label")).Text;
            // извлекаем из нее число
            Match m = new Regex(@"\d+").Match(text);
            // преобразуем в число
            return Int32.Parse(m.Value);
        }

        /*public List<ContactData> GetContactList()
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
        }*/
    }
}
