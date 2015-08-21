using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.DataStructure.List
{
    public class Queue<T>
    {
        private T _tail;
        private LinkedList<T> _list = null;

        public T Top 
        {
            get { return _tail;}
        }

        public Queue()
        {
            _list = new LinkedList<T>();
        }

        public void EnQueue(T element) 
        {
            _tail = element;
            _list.Append(element);
        }

        public T DeQueue()
        {
            var element = _list.Get(0);
            _list.Remove(0);

            if (element != null)
                return element.Content;

            return _tail;
        }
    }
}
