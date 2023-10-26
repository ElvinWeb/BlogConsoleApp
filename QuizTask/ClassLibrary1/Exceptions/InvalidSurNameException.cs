using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Exceptions
{
    public class InvalidSurNameException : Exception
    {

        public InvalidSurNameException()
        {

        }

        public InvalidSurNameException(string msg) : base(msg)
        {

        }
    }
}
