﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitNewGroupToCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            groupHelper.FullGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
        }

    }
}

