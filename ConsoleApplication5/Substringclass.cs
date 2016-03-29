using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Substringclass
    {
        public static String Truncate(String input, int maxLength)
        {
            if (input.Length > maxLength)
                return input.Substring(0, maxLength);
            else
            return input;
        }
        public static String Truncate_last(String input, int start)
        {
           // if (input.Length > maxLength)
                int maxLength = input.Length;
                string x = null;
                if (maxLength > start)
                { x = input.Substring(start, maxLength-start); }
                else
                { x=null; }
                return x;
         //   else
            //    return input;
        }
    }
}
