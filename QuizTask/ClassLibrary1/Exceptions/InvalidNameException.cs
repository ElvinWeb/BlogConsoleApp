using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Exceptions
{
    public class InvalidNameException : Exception
    {

        public InvalidNameException()
        {

        }

        public InvalidNameException(string msg) : base(msg)
        {

        }
    }
}
