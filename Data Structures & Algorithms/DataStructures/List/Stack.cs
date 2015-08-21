using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.DataStructure.List
{
    public class Stack<T>
    {
        private LinkedList<T> _list = null;

        public T Top()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty");

            return _list.Get(_list.Length-1).Content;
        }

        public Stack()
        {
            _list = new LinkedList<T>();
        }

        public void Push(T element)
        {
            _list.Append(element);
        }

        public T Pop()
        {
            if(IsEmpty())
                throw new Exception("Stack is empty");

            var top = _list.Get(_list.Length-1).Content;
            _list.Remove(_list.Length-1);

            return top;
        }

        public bool IsEmpty()
        {
            return (_list.Length == 0);
        }
    }
}
