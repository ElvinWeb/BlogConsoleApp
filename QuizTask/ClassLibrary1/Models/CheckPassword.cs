using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public static class CheckPassword
    {

        public static bool Check(string value)
        {
            int countDigit = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                {
                    countDigit++;
                }
            }

            if (value.Length >= 8 && char.IsUpper(value[0]) && value != null && countDigit >= 1)
            {
                return true;
            }

            return false;
        }
    }
}
