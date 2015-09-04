using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stack
{
    class CalculateExpression
    {
        public enum Operators
        {
            Subtraction = 0,
            Addition = 0,
            Division = 1,
            Multiplication = 1,
            Exponent = 2,
            OpenParenthesis = 3
        }

        Stack<string> initStack;

        private string expression;

        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public CalculateExpression()
        {
            initStack = new Stack<string>();
        }

        public CalculateExpression(string expression)
            : this()
        {
            this.expression = expression;
        }

        public double Calculate()
        {
            CheckNullExpression();

            char[] arr = (expression.Replace(" ", "") + ")").ToArray();

            int length = arr.Length;
            int numSize = 0;
            double[] arrNum = new double[numSize];

            initStack.Push("(");
            for (int i = 0; i < length; i++)
            {
                string curOperator = arr[i].ToString();
                if (IsOperator(curOperator))
                {
                    if (PriorityValue(curOperator) > PriorityValue(initStack.Peek()) || initStack.Peek() == "(")
                    {
                        initStack.Push(curOperator);
                    }
                    else
                    {
                        if (curOperator == ")")
                        {
                            do
                            {
                                arrNum[numSize - 2] = Operate(initStack.Pop(), arrNum[numSize - 2], arrNum[numSize - 1]);
                                Array.Resize(ref arrNum, --numSize);
                            } while (initStack.Peek() != "(");
                            initStack.Pop();
                        }
                        else
                        {
                            arrNum[numSize - 2] = Operate(initStack.Pop(), arrNum[numSize - 2], arrNum[numSize - 1]);
                            Array.Resize(ref arrNum, --numSize);
                            i--;
                        }
                    }
                }
                else
                {
                    Array.Resize(ref arrNum, ++numSize);
                    arrNum[numSize - 1] = Convert.ToDouble(arr[i].ToString());
                }
            }
            return arrNum[0];
        }

        private static bool IsOperator(string curOperator)
        {
            return curOperator == "(" || curOperator == ")" || curOperator == "^" || curOperator == "*"
                                || curOperator == "/" || curOperator == "+" || curOperator == "-";
        }

        private double Operate(string op, double num1, double num2)
        {
            switch (op)
            {
                case "^":
                    return Math.Pow(num1, num2);
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                default:
                    return 0;
            }
        }

        private int PriorityValue(string op)
        {
            switch (op)
            {
                case "^":
                    return (int)Operators.Exponent;
                case "*":
                    return (int)Operators.Multiplication;
                case "/":
                    return (int)Operators.Division;
                case "+":
                    return (int)Operators.Addition;
                case "-":
                    return (int)Operators.Subtraction;
                case "(":
                    return (int)Operators.OpenParenthesis;
                default:
                    return -1;
            }
        }

        private void CheckNullExpression()
        {
            if (String.IsNullOrEmpty(this.expression) || String.IsNullOrWhiteSpace(this.expression))
                throw new NullReferenceException("Input a valid expression!");
        }
    }
}
