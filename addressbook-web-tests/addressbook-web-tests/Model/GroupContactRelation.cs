using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace webAddressbookTests
{
    // устанавливаем связи между объектами
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation
    {
        // в таблице берем id-номер группы
        [Column(Name = "group_id")]
        public string GroupId { get; set; }

        // в таблице бере id-номер контакта
        [Column(Name = "id")]
        public string ContactId { get; set; }
    }
}
