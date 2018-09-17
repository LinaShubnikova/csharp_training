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

    public class ContactRemovalTests : AuthTestBase //TestBase
    {
        protected ContactHelper contactHelper;

        [Test]
        public void ContactRemovalTest()
        {
            // Переходим на страницу контактов
            app.Navigator.GoToHomePage();
            // Если нет контактов на странице, то создаем контакт
            if (!contactHelper.IsElementPresent(By.Name("selected[]")))
            {
                contactHelper.Create(new ContactData("tt", "zz"));
            }

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<ContactData> oldContacts = app.User.GetContactList();

            app.User.ContactDelete(0);

            Assert.AreEqual(oldContacts.Count - 1 , app.User.GetContactCount());

            List<ContactData> newContacts = app.User.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            app.Navigator.GoToHomePage();
            //List<GroupData> newGroups = app.Groups.GetGroupList();

            //oldGroups.RemoveAt(0);

            //Assert.AreEqual(oldGroups, newGroups);
        }
            
    }
}
