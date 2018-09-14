using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase //TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.IfNoGroupsCreateGroup();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                //Assert.AreNotEqual(group.Id, oldGroups[0].Id);
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
