using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Exceptions
{
    public class BlogNotFoundException : Exception
    {
        public BlogNotFoundException()
        {

        }

        public BlogNotFoundException(string msg) : base(msg)
        {

        }
    }
}
