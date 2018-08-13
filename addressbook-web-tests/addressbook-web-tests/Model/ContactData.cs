using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        private string middlename;
        private string nickname;
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

        public ContactData(string firstname, string lastname, string middlename, string nickname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.middlename = middlename;
            this.nickname = nickname;
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
