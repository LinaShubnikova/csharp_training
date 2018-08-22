using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]

    public class GroupModificationTest : AuthTestBase //TestBase
    {
        [Test]
        public void GroupModificationTests()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(0, newData);


        }
    }
}
