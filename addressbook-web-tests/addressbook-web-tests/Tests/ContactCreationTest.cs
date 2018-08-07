using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Maria", "Sheveleva");
            app.User.Create(contact);

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
