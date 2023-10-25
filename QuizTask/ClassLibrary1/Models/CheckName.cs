using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public static class CheckName
    {
        public static bool IsValidName(string value)
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
