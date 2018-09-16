using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts(); 
            // берем список контактов и исключаем из него все контакты группы с индексом [0]
            ContactData contact =  ContactData.GetAll().Except(oldList).First();

            // действия
            app.User.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            // добавляем в старый список контактов новые, которые добавляли в группу с индексом 0
            oldList.Add(contact);

            // сортируем списки
            oldList.Sort();
            newList.Sort();

            // сравнение
            Assert.AreEqual(oldList, newList);
        }

    }
}
