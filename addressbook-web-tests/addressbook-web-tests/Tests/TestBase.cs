using System;
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
    public class TestBase
    {
        // определяем выполнять длинную проверку списков или нет
        public static bool PERFORM_LONG_UI_CHECKS = true;

        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            //app.Auth.Login(new AccountData("admin", "secret"));
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            //Random rnd = new Random();
            // формируем строку из числа умноженного на max
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            
            // формируем строку из букв
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                // формируем число в диапазоне от 0 до 1 rnd.NextDouble, умножаем на 223, 
                // прибавляем 32, так как ASCII и символы меньше не печатные
                // округляем и конвертируем в число Convert.ToInt32
                // округляем и конвертируем в символ Convert.ToChar
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
