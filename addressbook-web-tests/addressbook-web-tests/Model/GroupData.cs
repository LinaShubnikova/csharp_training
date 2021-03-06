﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace webAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        //private string name;
        private string header = ""; //поле хедер с пустым значением
        private string footer = "";

        public GroupData()
        {
        }

        public GroupData(string name)
        {
            //this.name = name;
            Name = name;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
            //return Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheader=" + Header + "\nfooter=" + Footer;
        }

        public int CompareTo(GroupData other)
        {
            // Если объекта не существует, то 1
            if (other is null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        //public GroupData(string name, string header, string footer)
        //{
        //    this.name = name;
        //    this.header = header;
        //    this.footer = footer;
        //}

        [Column(Name = "group_name")]
        public string Name { get; set; }
        /*{
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }*/

        [Column(Name = "group_header")]
        public string Header { get; set; }
        /*{
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }*/

        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        /*{
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }*/

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        // извлекаем из таблицы список контактов с условием, что берем по группу по id и контакт по c.Id
        public List<ContactData> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                            select c).Distinct().ToList();
            }
        }
    }
}
