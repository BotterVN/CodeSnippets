using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaNoi_Tower
{
    class Program
    {
        static void Main(string[] args)
        {
            Move(3, 'A', 'C', 'B');

            Console.ReadLine();
        }
        static void Move(int plate, char first, char final, char middle)
        {
            if (plate == 1) Console.WriteLine("{0} to {1}", first, final);
            else
            {
                Move(plate - 1, first, middle, final);
                Move(1, first, final, middle);
                Move(plate - 1, middle, final, first);
            }            
        }
    }
}
