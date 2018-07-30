using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Figure
    {
        private bool colored = false;       // закрашенность

        public bool Colored
        {
            get
            {
                return colored;            // взять переданный размер круга
            }

            set
            {
                colored = value;           // изменения размера круга
            }
        }
    }
}
