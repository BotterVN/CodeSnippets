using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterVN.CodeSnippets.Algorithm.Recursive
{
    class Sum
    {
        /// <summary>
        /// S = 1 + 2 + 3 + ... n
        /// </summary>
        /// <param name="n"></param>
        public void Form_1(int n)
        {
            if (n < 1) 
                Console.WriteLine("Please input value > 0");
            else
                Console.WriteLine("Result = {0}", Recursive_F1(n));
        }
        private int Recursive_F1(int n)
        {            
            if (n == 1) return 1;
            return Recursive_F1(n - 1) + n;
        }
        /// <summary>
        /// S = 1*2 + 2*3 + 3*4 + ... + (n-1)*n
        /// </summary>
        /// <param name="n"></param>
        public void Form_2(int n)
        {
            if (n < 1)
                Console.WriteLine("Please input value > 0");
            else
                Console.WriteLine("Result = {0}", Recursive_F2(n));
        }
        private int Recursive_F2(int n)
        {
            if (n == 1) return 0;
            return Recursive_F2(n - 1) + (n - 1) * n;
        }
        /// <summary>
        /// S = 1 - 2 + 3 - 4 + ... +/- n
        /// </summary>
        /// <param name="n"></param>
        public void Form_3(int n)
        { 
            if (n < 1)
            Console.WriteLine("Please input value > 0");
            else
            Console.WriteLine("Result = {0}", Recursive_F3(n));
        }
        private double Recursive_F3(double n)
        {
            if (n < 1) return 0;
            return Math.Pow(-1, n - 1) * n + Recursive_F3(n - 1);
        }
        /// <summary>
        /// Pi = 4 * (1 - 1/3 + 1/5 - 1/7 ... +(-) 1/n)
        /// </summary>
        /// <param name="n"></param>
        public double PI(int n)
        {
            return 4 * Incommensurable(n);
        }
        private double Incommensurable(int n)
        {
            if (n == 1) return 1;
            return Math.Pow(-1, n - 1) * ((double)1 / (2 * n - 1)) + Incommensurable(n - 1);
        }
    }
}
