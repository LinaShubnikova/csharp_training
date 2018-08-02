using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : TestBase
    {

        [Test]
        public void UserpCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            GoToUserCreationPage();
            FullUserForm(new UserData("Maria", "Sheveleva"));
            SubmitUserCreation();
            LogOut();
        }
    }
}
