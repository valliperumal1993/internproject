using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Class1
    {
                 //string text = System.IO.File.ReadAllText(@"D:\New folder\specialchar.txt");
        public void xxs()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\New folder\specialchar.txt");
            string[] lines1 = System.IO.File.ReadAllLines(@"D:\New folder\ccc.txt");

            string x = string.Join("", lines);
            string x1 = string.Join("$^", lines1).TrimEnd('^');
            //Console.Write(x=x.TrimEnd(''));
            int i;
            Console.Write(x);
            string pattern = "[" + x + "]";
            Console.Write("\n" + pattern);
            string a = "valli     absolut+-";
            //a =a.Replace(pattern, " ");
            string a1;
            string pattern1 = "^" + x1; ;
            a = Regex.Replace(a, pattern, "");
            Console.Write("\n" + a);
            Console.Write("\n" + pattern1);
            a = Regex.Replace(a, "\\s+", " ");
            Console.Write("\n" + a);
            a1 = Regex.Replace(a, pattern1, "");
            Console.Write("\n" + a1);
            // Console.Write("\n" + pattern1);
            string input = "hai vallicool cool va";//@"(\b"+"cool"+"\b)"
            String s = "cool";//s.Replace("\0",string.Empty)
            string pp = @"(\b" + s + "\\b)";
            int l = pp.Length;
            Console.Write("\n" + l);
            for (i = 0; i < pp.Length; i++)
            {
                Console.WriteLine(i + "\t" + pp[i]);
            }

            Console.WriteLine("________________");
            string pp1 = @"(\bcool\b)";
            int ll = pp1.Length;
            for (i = 0; i < pp1.Length; i++)
            {
                Console.WriteLine(i + "\t" + pp1[i]);
            }

            Console.WriteLine("________________");
            Console.Write("\n" + ll);
            input = Regex.Replace(input, pp, "supercool", RegexOptions.IgnoreCase);
            Console.WriteLine("\n" + input);


            var r = new System.Text.RegularExpressions.Regex("Result:(.)*");
            var result = r.Replace("Action  a b c Result:1231231", "");
            Console.WriteLine("\n" + result);
        }
    }
}
