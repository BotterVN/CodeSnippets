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
            Insert(val, null);
        }

        public AVL Insert(int val)
        {
            return Insert(val, null);
        }

        private AVL Insert(int val, AVL parent)
        {
            if (val > Value)
            {
                if (Right == null)
                {
                    var newNode = new AVL() { Value = val };
                    Right = newNode;
                }
                else
                    Right.Insert(val, this);
            }
            else
            {
                if(Left == null)
                {
                    var newNode = new AVL() { Value = val };
                    Left = newNode;
                }
                else
                    Left.Insert(val, this);
            }
            return BalanceTree(parent);
        }

        private AVL BalanceTree(AVL parent)
        {
            var bf = GetBalanceFactor();
            if(bf == 2)
            {
                var subBf = this.Left.GetBalanceFactor();
                if(subBf == -1) // left-right
                    this.Left.RotateLeft(this);
                 
                // left-left
                return this.RotateRight(parent);
            }
            else if(bf == -2)
            {
                var subBf = this.Right.GetBalanceFactor();
                if(subBf == 1) // right-left
                    this.Right.RotateRight(this);

                return this.RotateLeft(parent);
            }
            else
                return this;
        }

        public int GetBalanceFactor()
        {
            return Height(this.Left) - Height(this.Right);
        }

        public int Height()
        {
            return Height(this);
        }

        public int Height(AVL tree)
        {
            if (tree == null)
                return 0;

            return 1 + Math.Max(Height(tree.Left), Height(tree.Right));
        }

        private AVL RotateLeft(AVL parent)
        {
            var right = this.Right;

            this.Right = right.Left;
            right.Left = this;

            if(parent != null)
                parent.Left = right;

            return right;
        }

        private AVL RotateRight(AVL parent)
        {
            var left = this.Left;

            this.Left = left.Right;
            left.Right = this;

            if(parent != null)
                parent.Right = left;

            return left;
        }

        public void Print()
        {
            Console.WriteLine("@@@@@@@@@@");
            Print(0);
        }

        private void Print(int level)
        {
            PrintMultiple(" ", level * 3);
            Console.WriteLine("+- {0}", Value);

            if (Left != null)
                Left.Print(level + 1);

            if (Right != null)
                Right.Print(level + 1);
            
        }

        public void PrintMultiple(string s, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(s);
            }
        }

        public int NumChildren()
        {
            return NumChildren(this);
        }

        public int NumChildren(AVL tree)
        {
            return 1 + NumChildren(tree.Left) + NumChildren(tree.Right);
        }
    }
}
