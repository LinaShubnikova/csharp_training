﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase //TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Maria", "Sheveleva");

            List<ContactData> oldContacts = app.User.GetContactList();

            app.User.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.User.GetContactCount());

            List<ContactData> newContacts = app.User.GetContactList();
            //Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            /*app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            GoToUserCreationPage();
            FullUserForm(new ContactData("Maria", "Sheveleva"));
            SubmitUserCreation();
            LogOut();
            */
        }
    }
}
