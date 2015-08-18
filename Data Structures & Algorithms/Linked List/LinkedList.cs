using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Postfix
{
    public class LinkedList<T>
    {
        public Node<T> Root { get; set; }
        public int Length { get; set; }

        public void Append(T content)
        {
            // 1. create a new node
            var newNode = new Node<T>()
            {
                Content = content,
                Next = null
            };

            // 2. identify the tail of the list
            var currentNode = Root;
            if (currentNode == null) Root = newNode;
            else
            {
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }

            this.Length += 1;
        }

        public bool Insert(int index, T content)
        {

            var newNode = new Node<T>()
            {
                Content = content,
                Next = null
            };

            if (index == 0)
            {
                newNode.Next = Root;
                Root = newNode;

                this.Length += 1;
                return true;
            }

            if (index < this.Length && index > 0)
            {
                var currentNode = this.Get(index - 1);
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;                

                this.Length += 1;
                return true;
            }
            return false;
        }

        public bool Remove(int index)
        {
            if (Root == null) return false;

            if (Root.Next == null)
            {
                if (index == 0)
                {
                    Root = Root.Next;
                    this.Length--;
                    return true;
                }
                return false;
            }

            if (index == 0)
            {
                Root = Root.Next;
                this.Length--;
                return true;
            }

            var curNode = Root;
            for (int i = 0; i < index - 1; i++)
            {
                curNode = curNode.Next;
                // check out of range
                if (curNode.Next == null) return false;
            }

            curNode.Next = curNode.Next.Next;
            this.Length--;
            return true;
        }

        public Node<T> Get(int index)
        {
            if (index < 0 || index >= this.Length) return null;

            var i = 0;
            var currentNode = Root;
            while (currentNode != null)
            {
                if (i == index) return currentNode;
                currentNode = currentNode.Next;
                i++;
            }

            return null;
        }        

        public string ToOutString()
        {
            var st = "";
            var curNode = Root;
            while (curNode != null)
            {
                st += curNode.Content.ToString() + " ";
                curNode = curNode.Next;
            }

            return st;
        }

        public string OutRevertString()
        {
            var st = "";
            var curNode = Root;
            while (curNode != null)
            {
                st = curNode.Content.ToString() + st;
                curNode = curNode.Next;
            }

            return st;
        }
    }
}
