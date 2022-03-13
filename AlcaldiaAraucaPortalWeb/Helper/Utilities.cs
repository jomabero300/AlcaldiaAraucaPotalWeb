using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper
{
    public class Utilities
    {
        public static string StartCharacterToUpper(string str)
        {
            string x = str.Substring(0, 1);

            x = x.ToUpper();

            str = x + str.Substring(1, str.Length - 1);

            return str;
        }
    }
}
