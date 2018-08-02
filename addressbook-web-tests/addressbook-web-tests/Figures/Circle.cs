using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Circle : Figure
    {
        private int radius;                 // поле круга "радиус"

        public Circle(int radius)           // конструктор
        {
            this.radius = radius;
        }

        public int Radius
        {
            get
            {
                return radius;            // взять переданный размер круга
            }

            set
            {
                radius = value;           // изменения размера круга
            }
        }


    }
}
