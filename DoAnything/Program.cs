using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnything
{
    class Program
    {
        static void Main(string[] args)
        {
            var networkElement = "ADKILL";
            List<string> mmlCommands = new List<string>();
            mmlCommands.Add($"DSP CELLUECNT; {{{networkElement}}}");
            var stop = 1;
        }
    }
}
