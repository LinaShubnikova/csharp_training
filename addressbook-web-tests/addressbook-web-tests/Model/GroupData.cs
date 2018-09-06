using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        //private string name;
        private string header = ""; //поле хедер с пустым значением
        private string footer = "";

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
            if (Object.ReferenceEquals(other, null)) // если равны, то вернуть единицу
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

        public string Id { get; set; }
    }
}
