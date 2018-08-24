using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        private string middlename;
        private string nickname;

        //public ContactData(string text)
        //{
        //}

        /*private string title = "";
private string company = "";
private string address = "";
private string home = "";
private string mobile = "";
private string work = "";
private string fax = "";
private string email = "";
private string email1 = "";
private string email2 = "";
private string homepage = "";
private string notes = "";*/

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            //this.middlename = middlename;
            //this.nickname = nickname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(this.Lastname, other.Lastname) == true)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
            //return Firstname.CompareTo(other.Firstname) & Secondname.CompareTo(other.Secondname);
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + " " + "secondname=" + Lastname;
        }

        public override int GetHashCode()
        {
            // return 0;
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

    }
}
