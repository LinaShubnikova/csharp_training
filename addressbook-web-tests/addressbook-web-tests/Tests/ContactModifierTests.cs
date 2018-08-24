using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]

    class ContactModifierTests : AuthTestBase //TestBase
    {
        [Test]
        public void ContactModifierTest()
        {
            ContactData contact = new ContactData("Maria", "Sheveleva");
            contact.Middlename = null;
            contact.Nickname = null;

            List<ContactData> oldContacts = app.User.GetContactList();

            app.User.ModifierContact(contact);

            List<ContactData> newContacts = app.User.GetContactList();
            oldContacts[0].Lastname = contact.Lastname;
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
