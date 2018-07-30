using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Square : Figure
    {
        private int size;               // размер

        public Square(int size)         // конструктор
        {
            this.size = size;           // использовать переданный параметр размера
        }

        public int Size                 // проперти для гет и сет
        {
            get
            {
                return size;            // взять переданный размер квадрата
            }

            set
            {
                size = value;           // изменения размера квадрата
            }
        }

    }
}
