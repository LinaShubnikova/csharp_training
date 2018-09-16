﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase //AuthTestBase // TestBase
    {
        // генерируем файлы генератором
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                });
            }

            return groups;
        }
        
        // читаем из файла данные для заполнения полей групп
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            // "список" одной строкой
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                // список, разделенный по запятой
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        // читаем из файла данные для заполнения полей групп
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            //List<GroupData> groups = new List<GroupData>();
            // приводим к типу (List<GroupData>) 
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        //[Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();

            //GroupData group = new GroupData("qwer");
            //group.Header = "qw";
            //group.Footer = "er";
            app.Groups.Create(group);

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            //int count = app.Groups.GetGroupCount(); // берем количество групп
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count); // берем количество групп после добавления и сравниваем с кол-вом до добавления
            //Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups );
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        /*[Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);
        }*/

        [Test]
        public void BadNameGroupCreationTest()
        {

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);

        }

        // подключение к БД и взятие списка групп из таблицы
        /*[Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;

            List<GroupData> fromUI = app.Groups.GetGroupList();

            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();
            /*using (AddressbookDB db = new AddressbookDB())
            {
                List<GroupData> fromDB = (from g in db.Groups select g).ToList();
            }*/
            //AddressbookDB db = new AddressbookDB();
            //List<GroupData> fromDB = (from g in db.Groups select g).ToList();
            //db.Close();

            //end = DateTime.Now;
            //System.Console.Out.WriteLine(end.Subtract(start));

        //}*/

        [Test]
        public void TestDBConnectivity()
        {
            // извлекли все группы, из них берем нулевую и извлекаем у этой группы все контакты
            //foreach (ContactData contact in GroupData.GetAll()[0].GetContacts())
            foreach (ContactData contact in ContactData.GetAll())
                {
                System.Console.Out.WriteLine(contact.Deprecated);
            }
        }
    }
}

