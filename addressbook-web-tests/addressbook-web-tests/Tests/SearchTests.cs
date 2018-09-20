using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressbookTests
{

    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]

        public void TestSearch()
        {
            //System.Console.Out.Write(app.User.GetNumberOfSearchResults());
            int countNumber = app.User.GetNumberOfResults("p");
            int trNumber = app.User.GetNumberOfContactsSearch();
            Assert.AreEqual(countNumber, trNumber);
        }

    }
}
