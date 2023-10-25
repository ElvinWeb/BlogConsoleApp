using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Exceptions
{
    internal class InvalidPasswordException : Exception

    {
        public InvalidPasswordException()
        {
                
        }

        public InvalidPasswordException(string msg) : base(msg)
             
        {

        }
    }
}
