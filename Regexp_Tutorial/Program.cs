using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regexp_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            string stc = "fanksoxisxm_sidock,_02_34";
            stc = stc.Substring(0, stc.LastIndexOf(","));
            Console.WriteLine(stc);
        }
    }
}
