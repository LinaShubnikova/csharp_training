﻿using System;
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
    public class GroupCreationTests : AuthTestBase // TestBase
    {

        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }
    }
}

