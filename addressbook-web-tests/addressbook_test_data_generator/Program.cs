using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace addressbook_test_data_generators
{
    class Program
    {
        //формируем строки из случайным образом сгенерированных данных спомощью GenerateRandomString
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
                //string str = String.Format("${0},${1},${2}",
                /*writer.WriteLine(String.Format("${0},${1},${2}",
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10)));
                */
                //System.Console.Out.WriteLine(str);

                //writer.WriteLine(str);
            }
            if (format == "csv")
            {
                writeGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format " + format);
            }
            writer.Close();
            //System.Console.Out.Write("Hello, world!");
        }

        // Записываем строки в файл в формате CSV
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        // Записываем строки в файл в формате XML
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
    }
}
