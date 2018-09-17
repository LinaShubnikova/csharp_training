﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace webAddressbookTests
{
    [Table (Name = "addressbook")]
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        //private string firstname;
        //private string lastname;
        private string middlename;
        private string nickname;
        private string address;
        private string allPhones;
        private string allEmail;
        private string homePhone;
        private string mobilePhone;
        private string workPhone;
        private string allData;
        private string allName;
        private string homePhoneWithPrefix;
        private string mobileFoneWithPrefix;
        private string workFoneWithPrefix;
        private string faxFoneWithPrefix;
        //private string fax;

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

        public ContactData(string allName)
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            HomePhone = homePhone;
            MobilePhone = mobilePhone;
            WorkPhone = workPhone;

            AllPhones = allPhones;
            AllEmail = allEmail;
            //AllData = allData;
            AllName = allName;

            //Fax = fax;
            //Email = email;
            //Email1 = email1;
            //Email2 = email2;
            //Homepage = homepage;
            //Notes = notes;
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
            // Если объекта не существует, то 1
            if (other is null)
            {
                return 1;
            }
            //else if(this.Firstname == other.Firstname)
            //{
            // Если совпали имена, то сравниваем фамилии (0 если полностью совпали)
            //    return Lastname.CompareTo(other.Lastname);
            //}
            //return Firstname.CompareTo(other.Firstname);
            string firstnameLastname = Firstname + Lastname;
            string otherFirstnameLastname = other.Firstname + other.Lastname;
            return firstnameLastname.CompareTo(otherFirstnameLastname);
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + " " + "lastname=" + Lastname;
        }

        public override int GetHashCode()
        {
            // return 0;
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        //{
        //get
        //{
        //    return firstname;
        //}
        //set
        //{
        //    firstname = value;
        //}
        //}

        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        /*public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    return (Firstname + " " + Lastname + "\r\n" + Address + "\r\n"
                        + "\r\n"
                        + "H: " + HomePhone + "\r\n"
                        + "M: " + MobilePhone + "\r\n"
                        + "W: " + WorkPhone + "\r\n"
                        //+ "W: " + Fax + "\r\n"
                        + "\r\n"
                        + Email + "\r\n"
                        + Email2 + "\r\n"
                        + Email3);
                }

            }
            set
            {
                allData = value;
            }
        }*/

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }


        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }

            }
            set
            {
                allEmail = value;
            }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ ]", "") + "\r\n";
            //return email.Replace(" ", "") + "\r\n";
        }


        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

        public string HomePhoneWithPrefix
        {
            get
            {
                if (homePhoneWithPrefix != null)
                {
                    return homePhoneWithPrefix;
                }
                else
                {
                    return ("H:" + " " + (HomePhone));
                }
            }
            set
            {
                homePhoneWithPrefix = value;
            }
        }
        public string MobilePhoneWithPrefix
        {
            get
            {
                if (mobileFoneWithPrefix != null)
                {
                    return mobileFoneWithPrefix;
                }
                else
                {
                    return ("M:" + " " + (MobilePhone));
                }
            }
            set
            {
                mobileFoneWithPrefix = value;
            }
        }
        public string WorkPhoneWithPrefix
        {
            get
            {
                if (workFoneWithPrefix != null)
                {
                    return workFoneWithPrefix;
                }
                else
                {
                    return ("W:" + " " + (WorkPhone));
                }
            }
            set
            {
                workFoneWithPrefix = value;
            }
        }
        public string FaxFoneWithPrefix
        {
            get
            {
                if (faxFoneWithPrefix != null)
                {
                    return faxFoneWithPrefix;
                }
                else
                {
                    return ("F:" + " " + (Fax));
                }
            }
            set
            {
                faxFoneWithPrefix = value;
            }
        }

        public string AllName
        {
            get
            {
                if (allName != null)
                {
                    return allName;
                }
                else
                {
                    return ((Firstname) + " " + (Lastname));
                }
            }
            set
            {
                allName = value;
            }
        }
    }
}
