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

    public class ContactInformationTest : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            // информация о контакте с главной страницы с индексом 0
            ContactData fromTable = app.User.GetContactInformationFromTable(0);
            // информация о контакте со страницы заполнения формы контакта с индексом 0
            ContactData fromForm = app.User.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }

        [Test]

        public void TestContactDetailInformation()
        {
            // информация о контакте с страницы после нажатия кнопки с человечком для контакта с индексом 0
            string detailInformation = app.User.GetContactDetailInformationFromTable(0);
            // информация о контакте со страницы заполнения формы контакта с индексом 0
            ContactData fromDetailForm = app.User.GetContactInformationFromEditForm(0);

			string infoFromEdit = fromDetailForm.AllData;

            Assert.AreEqual(detailInformation, infoFromEdit);
        }
    }
}
