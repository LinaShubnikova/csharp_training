using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = null;
            int attempt = 0;
            do
            {
                System.Threading.Thread.Sleep(1000); // подождать 1 секунду
                attempt++;
                //attempt = attempt + 1;
            } while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60); // пока счетчик равен нулю выполняем ожидание

            /*
            IWebDriver driver = null;
            int attempt = 0;
            while (driver.FindElements(By.Id("test")).Count ==0 && attempt < 60) // пока счетчик равен нулю выполняем ожидание
            {
                System.Threading.Thread.Sleep(1000); // подождать 1 секунду
                attempt++;
                //attempt = attempt + 1;
            }
            */

            /*string[] s = new string[] { "i", "Want", "to", "sleep" };

            foreach (string element in s)
            {
                System.Console.Out.Write(element + "\n");
            }
            /*for (int i=0; i<s.Length; i++)
            {
                System.Console.Out.Write(s[i] + "\n");
            }*/
        }
    }
}
