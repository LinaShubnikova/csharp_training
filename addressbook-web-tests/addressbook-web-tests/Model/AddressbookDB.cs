using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace webAddressbookTests
{
    public class AddressbookDB : LinqToDB.Data.DataConnection
    {
        public AddressbookDB() : base("AddressBook") { }

        // метод извлекает таблицу group_list
        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        // метод извлекает таблицу
        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }

        // метод извлекает таблицу address_in_groups
        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }
    }
}
