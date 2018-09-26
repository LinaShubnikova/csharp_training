using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{
	public class DeleteContactFromGroupTest : AuthTestBase
	{
		[Test]
		public void DeleteContactFromGroup()
		{
			GroupData group = GroupData.GetAll()[0];
			List<ContactData> oldList = group.GetContacts();

			if (oldList.Count == 0)
			{
				// Если нет контактов на странице, то создаем контакт
				app.User.IfNoContactsCreateContact();
				ContactData newContact = ContactData.GetAll()[0];
				// добавляем контакт в группу
				app.User.AddContactToGroup(newContact, group);
				oldList = group.GetContacts();
			}

			ContactData contact = oldList[0];

			app.User.DeleteContactFromGroup(contact, group);

			List<ContactData> newList = group.GetContacts();
			oldList.RemoveAt(0);
			newList.Sort();
			oldList.Sort();
			Assert.AreEqual(oldList, newList);
		}
	}
}
