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
            ContactData contact = new ContactData("Maria", "Sheveleva", "Anna", "MariAnn");
            app.User.ModifierContact(contact);
        }

    }
}
