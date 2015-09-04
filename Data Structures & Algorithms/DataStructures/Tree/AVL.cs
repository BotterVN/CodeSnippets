using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Tree
{
    enum Direction
    {
        None,
        Left,
        Right
    }

    class TraceNode
    {
        public TreeNode Node { get; set; }
        public TreeNode Parent { get; set; }
        public Direction Dir { get; set; }
    }

    public class TreeNode
    {
        public TreeNode(int val)
        {
            Value = val;
            Left = null;
            Right = null;
        }

        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    public class AVL
    {
        public TreeNode Root { get; set; }

        public AVL()
        {
            Root = null;
        }

        public void Insert(int val)
        {
            if (Root == null)
            {
                Root = new TreeNode(val);
                return;
            }

            var tracingNodes = new Stack<TraceNode>();

            var node = this.Root;
            tracingNodes.Push(new TraceNode() { Node = node, Parent = null });

            while(true)
            {
                if (val <= node.Value)
                    if (node.Left != null)
                    {
                        tracingNodes.Push(new TraceNode() { Node = node.Left, Parent = node, Dir = Direction.Left });
                        node = node.Left;
                    }
                    else
                        break;
                else
                    if (node.Right != null)
                    {
                        tracingNodes.Push(new TraceNode() { Node = node.Right, Parent = node, Dir = Direction.Right });
                        node = node.Right;
                    }
                    else
                        break;
            }

            var newNode = new TreeNode(val);
            if (val <= node.Value)
                node.Left = newNode;
            else
                node.Right = newNode;

            // balance tree
            while(tracingNodes.Count != 0)
                BalanceNode(tracingNodes.Pop());
        }

        public void Delete(int val)
        {
            // delete
            var node = Root;
            TreeNode parent = null;
            Direction dir = Direction.None;

            var tracingNodes = new Stack<TraceNode>();
            tracingNodes.Push(new TraceNode() { Node = node, Parent = parent, Dir = dir });

            while(node != null && node.Value != val)
            {
                parent = node;

                if (val <= node.Value)
                {
                    node = node.Left;
                    dir = Direction.Left;
                }
                else
                {
                    node = node.Right;
                    dir = Direction.Right;
                }

                tracingNodes.Push(new TraceNode() { Node = node, Parent = parent, Dir = dir });
            }

            if(node != null)
            {
                if (node.Left == null)
                {
                    if (dir == Direction.Left)
                        parent.Left = node.Right;
                    else
                        parent.Right = node.Right;
                }
                else
                {
                    // find right-most node
                    var snode = node.Left;
                    var sparent = node;
                    var sdir = Direction.Left;

                    while (snode.Right != null)
                        snode = snode.Right;
                    

                    node.Value = snode.Value;

                    var replaceNode = (snode.Left != null)?snode.Left:null;

                    if (sdir == Direction.Left)
                        sparent.Left = replaceNode;
                    else
                        sparent.Right = replaceNode;
                }
            }

            // balance
            while (tracingNodes.Count > 0)
                BalanceNode(tracingNodes.Pop());
        }

        #region Helpers
        private void BalanceNode(TraceNode tn)
        {
            var curNode = tn.Node;

            var bf = GetBalanceFactor(curNode);
            if (bf == 2)
            {
                var left = curNode.Left;
                var sbf = GetBalanceFactor(left);
                if (sbf == -1) // left-right tree
                    RotateLeft(left.Right, new TraceNode() { Node = left, Parent = curNode, Dir = Direction.Right });

                // left-left tree
                RotateRight(left, tn);
            }
            else if (bf == -2)
            {
                var right = curNode.Right;
                var sbf = GetBalanceFactor(right);
                if (sbf == 1) // right-left tree
                    RotateRight(Root.Left.Left, new TraceNode() { Node = right, Parent = curNode, Dir = Direction.Left });

                // right-right tree
                RotateLeft(right, tn);
            }
        }

        private void RotateRight(TreeNode node, TraceNode parent)
        {
            var parentNode = parent.Node;

            parentNode.Left = node.Right;
            node.Right = parentNode;

            if (parent.Parent != null)
            {
                if (parent.Dir == Direction.Left)
                    parent.Parent.Left = node;
                else
                    parent.Parent.Right = node;
            }
            else // root
            {
                Root = node;
            }
        }

        private void RotateLeft(TreeNode node, TraceNode parent)
        {
            var parentNode = parent.Node;

            parentNode.Right = node.Left;
            node.Left = parentNode;

            if (parent.Parent != null)
            {
                if (parent.Dir == Direction.Left)
                    parent.Parent.Left = node;
                else
                    parent.Parent.Right = node;
            }
            else // root
            {
                Root = node;
            }
        }

        public int Height()
        {
            return Height(this.Root);
        }

        public int NumChildren()
        {
            return NumChildren(this.Root);
        }

        private int Height(TreeNode tree)
        {
            if (tree == null)
                return 0;

            return 1 + Math.Max(Height(tree.Left), Height(tree.Right));
        }

        private int NumChildren(TreeNode tree)
        {
            if (tree == null) return 1;

            return 1 + NumChildren(tree.Left) + NumChildren(tree.Right);
        }

        private int GetBalanceFactor(TreeNode node)
        {
            return Height(node.Left) - Height(node.Right);
        }
        #endregion

        #region Debug
        public void Print()
        {
            Console.WriteLine(Multiple("_", 10));
            Print(Root, 1);
        }

        private void Print(TreeNode node, int level)
        {
            Console.WriteLine("{0}\\{1}_{2}",
                Multiple(" ", level * 3 - 2),
                Multiple("_", 1),
                (node != null) ? node.Value.ToString() : "*");

            if (node != null)
            {
                Print(node.Right, level + 1);
                Print(node.Left, level + 1);
            }
        }

        public string Multiple(string s, int n)
        {
            var result = "";
            while (n-- != 0)
                result += s;
            return result;
        }
        #endregion
    }
}
