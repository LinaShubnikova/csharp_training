using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            // ЕСЛИ ВКЛЮЧЕНЫ ДЛИННЫЕ ПРОВЕРКИ
            if (PERFORM_LONG_UI_CHECKS)
            {
                // берем список групп из польз интерфейса
                List<GroupData> fromUI = app.Groups.GetGroupList();
                // берем список групп из БД
                List<GroupData> fromDB = GroupData.GetAll();
                // сортируем списки
                fromUI.Sort();
                fromDB.Sort();
                // сравниваем списки
                Assert.AreEqual(fromUI, fromDB);
            }
            
        }
    }
}
