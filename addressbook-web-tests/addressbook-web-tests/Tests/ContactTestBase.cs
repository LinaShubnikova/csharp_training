using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{
	public class ContactTestBase : AuthTestBase
	{
		[TearDown]
		public void CompareContactUI_DB()
		{
			if (PERFORM_LONG_UI_CHECKS)
			{
				List<ContactData> fromUI = app.User.GetContactList();
				List<ContactData> fromDB = ContactData.GetAll();
				fromDB.Sort();
				fromUI.Sort();
				Assert.AreEqual(fromUI, fromDB);
			}
		}
	}

}