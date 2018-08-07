using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]

    public class GroupModificationTest : TestBase
    {
        [Test]
        public void GroupModificationTests()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "qqq";
            app.Groups.Modify(1, newData);


        }
    }
}
