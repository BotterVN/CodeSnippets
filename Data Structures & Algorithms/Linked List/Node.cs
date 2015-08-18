using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Postfix
{
    public class Node<T>
    {
        public T Content { get; set; }
        public Node<T> Next { get; set; }
    }
}
