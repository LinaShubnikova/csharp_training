﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace webAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitNewGroupToCreation();
            FullGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FullGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null) {
                        //groupCache.Add(new GroupData(element.Text));
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value"),
                        Name = element.Text
                    });
                }
                /*
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                for (int i = 0; i < groupCache.Count; i++)
                {
                    groupCache[1].Name = parts[i].Trim();
                }*/

            }
            /*List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                //GroupData group = new GroupData(element.Text);
                //groups.Add(group);
                groups.Add(new GroupData(element.Text));
            }*/
            return new List<GroupData>(groupCache);
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public int GetGroupCount() // метод находит количесво объектов класса span.group
        {
            return driver.FindElements(By.CssSelector("span.group")).Count; 
        }

        /*
        public GroupHelper Remove(int p)
        {
            if (IsGroupHave())
            {
                manager.Navigator.GoToGroupsPage();

                SelectGroup(p);
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
            }
            //создать группу
            app.Groups.GroupCreationTest(group);


        }

        public bool IsGroupHave(int index)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]"));
        }
        */

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string Id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+Id+"']) ")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitNewGroupToCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FullGroupForm(GroupData group) //string name, string header, string footer
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

       

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }


        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper IfNoGroupsCreateGroup()
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                Create(new GroupData("wwww"));
            }
            return this;
        }

    }
}
