using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterVN.CodeSnippets.Algorithm.Mathematic
{
    class UCLN
    {
        public static int Euclid(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            return (a == 0 || b == 0) ? a + b : Euclid(b, a % b);
        }
        public static int EuclidExplicit(int a, int b) 
        {
            if (a == 0) return b;                
            else if (b == 0)  return a;               
            else
            {
                a = Math.Abs(a);
                b = Math.Abs(b);

                int c;
                do
                {
                    c = a % b;
                    a = b;
                    b = c;
                } while (c != 0);
                return a;
            }
        }
        public static int Loop(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b) return a;
            while (a != b) 
            {
                if (a > b) a = a - b;
                else b = b - a;
            }
            return a;
        }
    }
}
