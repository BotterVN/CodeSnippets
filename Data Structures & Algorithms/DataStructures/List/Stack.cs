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
        private T _top;

        public T Top 
        {
            get { return _top; }
        }

        public Stack()
        {
            _list = new LinkedList<T>();
        }

        public void Push(T element)
        {
            _list.Append(element);
            _top = element;
        }

        public T Pop()
        {
            var endIdx = _list.Length - 1;
            if (endIdx >= 0)
            {
                _top = _list.Get(endIdx).Content;
                _list.Remove(endIdx);

                return _top;
            }
            else
                throw new Exception("Stack empty");
        }
    }
}
