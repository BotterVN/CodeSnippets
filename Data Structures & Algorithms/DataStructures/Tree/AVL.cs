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

        public AVL(int val)
        {
            Left = null;
            Right = null;
            Value = val;
        }

        public void Insert(int val)
        {

        }

        public void Delete(int val)
        {

        }

        public int Height()
        {
            return Height(this);
        }

        public int NumChildren()
        {
            return NumChildren(this);
        }

        #region Helpers
        private int Height(AVL tree)
        {
            if (tree == null)
                return 0;

            return 1 + Math.Max(Height(tree.Left), Height(tree.Right));
        }

        private int NumChildren(AVL tree)
        {
            return 1 + NumChildren(tree.Left) + NumChildren(tree.Right);
        }

        private int GetBalanceFactor()
        {
            return Height(this.Left) - Height(this.Right);
        }
        #endregion
    }
}
