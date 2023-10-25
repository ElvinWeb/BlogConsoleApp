using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    internal static class CheckSurname
    {

        public static bool IsValidSurname(string value)
        {
            if (value == " " && value == null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
