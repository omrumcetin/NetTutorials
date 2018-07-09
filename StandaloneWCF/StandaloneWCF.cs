using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandaloneWCF
{
    public class StandaloneWCF : IStandaloneWCF
    {
        public int Add(int val1,int val2)
        {
            return (val1 + val2);
        }
    }
}
