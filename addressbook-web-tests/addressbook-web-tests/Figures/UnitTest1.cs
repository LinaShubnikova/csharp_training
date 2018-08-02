using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class Unitled
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 5);               // проверка размера стороны первого квадрата
            Assert.AreEqual(s2.Size, 10);              // второго
            Assert.AreEqual(s3.Size, 5);               // третьего

            s3.Size = 15;                                 // изменяем размер квадрата s3, делаем его равным 15
            Assert.AreEqual(s1.Size, 15);              // проверяем размер квадрата s1

            s2.Colored = true;
        }


        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(5);
            Circle s2 = new Circle(10);
            Circle s3 = s1;

            Assert.AreEqual(s1.Radius, 5);               // проверка размера стороны первого квадрата
            Assert.AreEqual(s2.Radius, 10);              // второго
            Assert.AreEqual(s3.Radius, 5);               // третьего

            s3.Radius = 15;                                 // изменяем размер квадрата s3, делаем его равным 15
            Assert.AreEqual(s1.Radius, 15);              // проверяем размер квадрата s1

            s2.Colored = true;
        }
    }
}
