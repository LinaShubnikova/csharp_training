using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]

    public class ContactRemovalTests : AuthTestBase //TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.User.PicUpContact();

            //List<GroupData> newGroups = app.Groups.GetGroupList();

            //oldGroups.RemoveAt(0);

            //Assert.AreEqual(oldGroups, newGroups);
        }
            
    }
}
