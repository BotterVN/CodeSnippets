using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterVN.CodeSnippets.Algorithm.Mathematic
{
    class BCNN
    {
        public static int Get(int a, int b) 
        {
            return (a * b) / (UCLN.Euclid(a, b));
        }        
    }
}
