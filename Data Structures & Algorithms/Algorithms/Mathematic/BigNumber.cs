using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterVN.CodeSnippets.Algorithm.Mathematic
{
    class BigNumber
    {
        const int CONG = 1;
        const int TRU = 2;
        const int NHAN = 3;
        const int LUYTHUA = 4;
        const int GIAITHUA = 5;
        const int CHIA = 6;

        public void Init()
        {                        
            Console.WriteLine("1. Summation\n2. Subtraction\n3. Multiplication\n4. Exponentiation\n5. Factorial\n6. Division");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Your choise: ");
            string ch = Console.ReadLine();

            while (ch.Length > 2 || Int32.Parse(ch) < 1 || Int32.Parse(ch) > 6)
            {
                Console.WriteLine("Invalid value");
                Console.WriteLine("Try again");
                ch = Console.ReadLine();
            }

            Console.Write("Input first number: \t");
            string s_numFirst = Console.ReadLine();
            Console.Write("Input second number: \t");
            string s_numSecond = Console.ReadLine();                                    

            Console.Write("Result: \t\t");
            Main(ch, s_numFirst, s_numSecond);
        }
        private void SyncLength(ref string s1, ref string s2)
        {
            string extra = "";
            int limit = s1.Length - s2.Length;

            for (int i = 0; i < Math.Abs(limit); i++)
            {
                extra += "0";
            }

            if (limit < 0) 
            {                
                s1 = extra + s1;
            }
            else 
            {
                s2 = extra + s2;
            }
        }

        private void Main(string key, string s_numFirst, string s_numSecond)
        {            
            switch (Int32.Parse(key))
            {
                case CONG:
                    if (s_numFirst[0].ToString() != "-" && s_numSecond[0].ToString() != "-")
                    {
                        Console.WriteLine(Summation(s_numFirst, s_numSecond));
                    }
                    else if (s_numFirst[0].ToString() != "-" && s_numSecond[0].ToString() == "-")
                    {
                        Console.WriteLine(Subtraction(s_numFirst, s_numSecond.Remove(0, 1)));
                    }
                    else if (s_numFirst[0].ToString() == "-" && s_numSecond[0].ToString() != "-")
                    {
                        Console.WriteLine(Subtraction(s_numSecond.Remove(0, 1), s_numFirst));
                    }
                    else
                    {
                        Console.WriteLine("-" + Summation(s_numFirst.Remove(0, 1), s_numSecond.Remove(0, 1)));
                    }
                    break;
                case TRU: 
                    if (s_numFirst[0].ToString() != "-" && s_numSecond[0].ToString() != "-")
                    {
                        Console.WriteLine(Subtraction(s_numFirst, s_numSecond));
                    }
                    else if (s_numFirst[0].ToString() != "-" && s_numSecond[0].ToString() == "-")
                    {
                        Console.WriteLine(Summation(s_numFirst, s_numSecond.Remove(0, 1)));
                    }
                    else if (s_numFirst[0].ToString() == "-" && s_numSecond[0].ToString() != "-")
                    {
                        Console.WriteLine("-" + Summation(s_numFirst.Remove(0, 1), s_numSecond));
                    }
                    else
                    {
                        Console.WriteLine(Subtraction(s_numSecond.Remove(0, 1), s_numFirst.Remove(0, 1)));
                    }
                    break;
                case NHAN: Console.WriteLine(Multiplication(s_numFirst, s_numSecond));
                    break;
                case LUYTHUA:
                    string result = "";
                    bool IsNegativePow = false;

                    if (s_numSecond[0].ToString() == "-")
                    {
                        IsNegativePow = true;
                        s_numSecond = s_numSecond.Remove(0, 1);
                    }

                    if (s_numFirst[0].ToString() != "-")
                    {
                        Console.WriteLine(Exponentiation(s_numFirst, s_numSecond));
                    }
                    else
                    {
                        result = Exponentiation(s_numFirst.Remove(0, 1), s_numSecond);
                        if (Int32.Parse(s_numSecond[s_numSecond.Length - 1].ToString()) % 2 != 0)
                        {
                            result = "-" + result;
                        }
                    }
                    if (IsNegativePow)
                    {
                        result = Division("1", s_numFirst);                        
                    }
                    Console.WriteLine(result);
                    break;
                case GIAITHUA:
                    if (s_numFirst[0].ToString() == "-")
                    {
                        Console.WriteLine("Can't calculate");
                    }
                    else if (s_numFirst.ToString() == "0")
                    {
                        Console.WriteLine("1");
                    }
                    else
                    {
                        Console.WriteLine(Factorial(s_numFirst));
                    }                    
                    break;
                case CHIA: Console.WriteLine(Division(s_numFirst, s_numSecond));
                    break;
            }
        }

        private string Summation(string s1, string s2)
        {
            SyncLength(ref s1, ref s2);

            string result = "";            
            int extra = 0;            
            
            for (int i = s1.Length - 1; i > -1; i--)
            {
                int tmp = Plus(Int32.Parse(s1[i].ToString()), Int32.Parse(s2[i].ToString()), extra);
                result = (tmp % 10).ToString() + result;
                extra = tmp / 10;
            }
            return extra == 0 ? result : extra + result;
        }
        private int Plus(int a, int b, int extra)
        {            
            return a + b + extra;
        }

        private string Subtraction(string s1, string s2)
        {                                            
            int compareResult = CompareNumber(s1, s2);

            if (compareResult == 0)
            {
                return "0";                
            }

            string result = "";
            string negative = "";
            int extra = 0;

            if (compareResult < 0)
            {
                var tmp = s1;
                s1 = s2;
                s2 = tmp;
                negative = "-";
            }
            
            SyncLength(ref s1, ref s2);

            for (int i = s1.Length - 1; i > -1; i--)
            {                
                int tmp = Minus(Int32.Parse(s1[i].ToString()), Int32.Parse(s2[i].ToString()), extra);
                extra = (
                    (Int32.Parse(s1[i].ToString()) < Int32.Parse(s2[i].ToString())) ||
                    ((Int32.Parse(s1[i].ToString()) == Int32.Parse(s2[i].ToString())) && extra != 0)) ? 1 : 0;
                result = tmp + result;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].ToString() != "0") break;
                result = result.Remove(i, 1);
            }
            return negative + result;
        }
        private int Minus(int a, int b, int extra)
        {
            if ((a < b) || (a == b && extra != 0)) a += 10;
            return a - b - extra;
        }

        private string Multiplication(string s1, string s2)
        {            
            string result = "";
            string sign = "";

            if ((s1[0].ToString() == "-" && s2[0].ToString() == "-"))
            {
                s1 = s1.Remove(0, 1);
                s2 = s2.Remove(0, 1);
            }
            else if ((s1[0].ToString() == "-" && s2[0].ToString() != "-"))
            {
                sign = "-";
                s1 = s1.Remove(0, 1);
            }
            else if ((s1[0].ToString() != "-" && s2[0].ToString() == "-"))
            {
                sign = "-";
                s2 = s2.Remove(0, 1);
            }

            int compareResult = CompareNumber(s1, s2);            
            if (compareResult < 0)
            {
                string tmp = s1;
                s1 = s2;
                s2 = tmp;
            }

            string[] partialResult = new string[s2.Length];
            for (int i = s2.Length - 1; i > -1; i--)
            {
                partialResult[s2.Length - 1 - i] = SingleMultiplication(s1.ToString(), s2[i].ToString());
            }
            for (int i = 1; i < partialResult.Length; i++)
            {
                int j = 0;
                while (j < i) {
                    partialResult[i] += "0";
                    j++;
                };
            }

            result = partialResult[0];
            for (int i = 1; i < partialResult.Length; i++)
            {
                result = Summation(result, partialResult[i]);
            }
            return sign + result;
        }
        private string SingleMultiplication(string s1, string number)
        {
            string result = "";
            int extra = 0;

            for (int i = s1.Length - 1; i > - 1; i--)
            {
                int tmp = Multiple(Int32.Parse(s1[i].ToString()), Int32.Parse(number), extra);
                result = (tmp % 10).ToString() + result;
                extra = tmp / 10;
            }

            return extra == 0 ? result : extra + result;
        }
        private int Multiple(int a, int b, int extra)
        {
            return a * b + extra;
        }

        private string Exponentiation(string s1, string s2)
        {
            string result = "";
            if (s2 == "1") return s1;

            bool IsPowZero = true;
            for (int i = 0; i < s2.Length; i++)
            {
                if (s2[i].ToString() != "0")
                {
                    IsPowZero = false;
                }                
            }
            if (IsPowZero) return "1";

            result = s1;
            if (s2[0].ToString() == "-")
            {
                while (s2[1].ToString() != "1")
                {
                    result = Multiplication(result, s1);
                    s2 = Subtraction(s2, "1");
                }  
            }
            else
            {
                while(s2.ToString() != "1")
                {
                    result = Multiplication(result, s1);
                    s2 = Subtraction(s2, "1"); 
                }
            }
                      
            return result;
        }
        private string Factorial(string s1)
        {
            if (s1 == "1") return "1";
            return Multiplication(s1, Factorial(Subtraction(s1, "1")));
        }

        private string Division(string s1, string s2)
        {
            return "chia";
        }
        private double Divide(string s1, string s2)
        {
            return 0;
        }

        private int CompareNumber(string s1, string s2)
        {
            if (s1[0].ToString() != "-" && s2[0].ToString() != "-")
            {
                return ComparePositiveNumber(s1, s2);
            }
            else if (s1[0].ToString() != "-" && s2[0].ToString() == "-")
            {
                return 1;
            }
            else if (s1[0].ToString() == "-" && s2[0].ToString() != "-")
            {
                return -1;
            }
            else
            {
                string cloneS1 = s1;
                cloneS1.Replace('-', '0');
                string cloneS2 = s2;
                cloneS2.Replace('-', '0');

                return (-1) * ComparePositiveNumber(cloneS1, cloneS2);
            }                      
        }
        private int ComparePositiveNumber(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                return 1;
            }
            else if (s1.Length < s2.Length)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] > s2[i]) return 1;
                    else if (s1[i] < s2[i]) return -1;
                    else continue;
                }
                return 0;
            }  
        }
    }
}
