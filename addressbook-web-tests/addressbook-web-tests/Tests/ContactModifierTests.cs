using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace webAddressbookTests
{
    [TestFixture]

    class ContactModifierTests : GroupTestBase //AuthTestBase //TestBase
    {
        //protected IWebDriver driver;
        protected ContactHelper contactHelper;

        [Test]
        public void ContactModifierTest()
        {
            // Данные для модификации контакта
            ContactData contact = new ContactData("Maria", "Sheveleva");
            contact.Middlename = null;
            contact.Nickname = null;

            // Переходим на страницу контактов
            app.Navigator.GoToHomePage();
            // Если нет контактов на странице, то создаем контакт
            if (!contactHelper.IsElementPresent(By.Name("selected[]")))
            {
                contactHelper.Create(new ContactData("tt", "zz"));
            }
            
            List<ContactData> oldContacts = app.User.GetContactList();

            app.User.ModifierContact(1, contact);

            Assert.AreEqual(oldContacts.Count, app.User.GetContactCount());

            List<ContactData> newContacts = app.User.GetContactList();
            oldContacts[0].Lastname = contact.Lastname;
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
