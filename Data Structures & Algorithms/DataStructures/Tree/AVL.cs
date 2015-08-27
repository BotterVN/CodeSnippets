using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Tree
{
    public class AVL
    {
        public AVL Left { get; set; }
        public AVL Right { get; set; }
        public int Value { get; set; }

        public AVL()
        {
            Left = null;
            Right = null;
        }

        public void InsertWithAutoBalance(int val)
        {
            Insert(val);
        }

        public void Insert(int val)
        {
            if (val > Value)
            {
                if (Right == null)
                {
                    var newNode = new AVL() { Value = val };
                    Right = newNode;
                }
                else
                    Right.Insert(val);
            }
            else
            {
                if(Left == null)
                {
                    var newNode = new AVL() { Value = val };
                    Left = newNode;
                }
                else
                    Left.Insert(val);
            }
        }

        private void RotateLeft()
        {

        }

        public void Print()
        {

        }
    }
}
