using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET4
{
    public class Student4
    {
        private string _Name = string.Empty;
        private string _Cet = string.Empty;

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public string Cet
        {
            set { _Cet = value; }
            get { return _Cet; }
        }
    }
}
