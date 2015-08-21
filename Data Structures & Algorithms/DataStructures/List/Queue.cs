using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.DataStructure.List
{
    public class Queue<T>
    {
        private LinkedList<T> _list = null;

        public T Top()
        {
            if (IsEmpty())
                throw new Exception("queue is empty");

            return _list.Get(0).Content;
        }

        public Queue()
        {
            _list = new LinkedList<T>();
        }

        public bool IsEmpty()
        {
            return (_list.Length == 0);
        }

        public void EnQueue(T element) 
        {
            _list.Append(element);
        }

        public T DeQueue()
        {
            if (IsEmpty())
                throw new Exception("queue is empty");

            var element = _list.Get(0);
            _list.Remove(0);

            return element.Content;
        }
    }
}
