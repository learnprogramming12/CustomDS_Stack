using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2
{

    public class DynamicStackException : System.Exception
    {
        public DynamicStackException(string strMessage) : base(strMessage) { }
    }
    // The underlying data structure of the dynamic stack implemented by a double linked list.
    // It can perform operations such as Push(), Pop(), Peek().
    internal class DynamicStack<T> where T : IEquatable<T>
    {
        private DoubleLinkedList<T> _list;
        public DynamicStack()
        {
            _list = new DoubleLinkedList<T>(); 
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public void Push(T tValue)
        {
            if(null == _list.AddFirst(tValue))
                throw new DynamicStackException("There is no enough memory to push the value: " + tValue.ToString());
        }
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new DynamicStackException("The stack is empty.");
            }
            T tValue = _list.First.Value;
            _list.RemoveFirst();
            return tValue;
        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new DynamicStackException("The stack is empty.");
            }
            return _list.First.Value;
        }
        public T GetElement(int iIndex)
        {
            return _list[iIndex];
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool IsEmpty()
        {
            return _list.IsEmpty();
        }


/*
        private class Node
        {
            public int _value;
            public Node _next;
            public Node(int iValue)
            {
                _value = iValue;
                _next = null;
            }
        }
        private Node _top = null;

        public DynamicStack()
        {
            _top = null;
        }
        /// <summary>
        /// This method can push a value into the stack
        /// </summary>
        /// <param name="iValue"></param>
        public void Push(int iValue)
        {
            Node node;
            try
            {
                node = new Node(iValue);
            }
            catch (OutOfMemoryException e)
            {
                throw new DynamicStackException("There is no enough memory to push the value: " + iValue.ToString());
            }
            node._next = _top;
            _top = node;
        }
        /// <summary>
        /// This method returns the value of the top end element in stack and removes it.
        /// </summary>
        /// <returns>the value or throw the DynamicStaticException</returns>
        /// <exception cref="DynamicStaticException"></exception>
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new DynamicStackException("The stack is empty.");
            }
            Node node = _top;
            _top = node._next;
            return node._value;
        }
        /// <summary>
        /// This method can return the value of the top end element of the stack or throw an exception if the stack is empty.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DynamicStaticException"></exception>
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new DynamicStackException("The stack is empty.");
            }
            return _top._value;
        }
        public void Clear()
        {
            _top = null;
        }
        public bool IsEmpty()
        {
            return (_top == null);
        }*/
    }
}
