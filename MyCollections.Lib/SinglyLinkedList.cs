using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections.Lib
{
    public class SinglyLinkedList<T> : IList<T>, IEnumerator<T>
    {
        #region Fields
        int _count;
        Node _head;
        Node _tail;
        #endregion

        #region InnerClasses
        class Node
        {
            public T _value;
            public Node _next;

            public Node(T value, Node next)
            {
                _value = value;
                _next = next;
            }
        }
        #endregion

        #region Ctors
        public SinglyLinkedList()
        {
        }

        public SinglyLinkedList(IEnumerable<T> items)
        {
            foreach (T item in items)
                Add(item);
        }
        #endregion

        #region Indexer

        private Node GetNode(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = _head;

            while (index-- > 0)
            {
                tmp = tmp._next;
            }
            return tmp;
        }

        public T this[int index]
        {
            get => GetNode(index)._value;
            set => GetNode(index)._value = value;
        }

        #endregion

        #region Properties

        public int Count => _count;

        public bool IsReadOnly => false;

        #endregion

        #region Ilist
        /// <summary>
        /// Add To Tail
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
           Node node = new Node(value, null);
 
            if (_head == null)
                _head = node;
            else
                _tail._next = node;
            _tail = node;
         
            ++_count;
        }

        /// <summary>
        /// Add To Head
        /// </summary>
        /// <param name="value"></param>
        public void AppendFirst(T value)
        {
            Node node = new Node(value, _head);
            _head = node;
            if (_count == 0)
                _tail = _head;
            _count++;
        }

        public void Clear()
        {          
                _head = _tail = null;
                _count = 0;           
        }

        public bool Contains(T item)
        {
            using (IEnumerator<T> en = GetEnumerator())
            {
                while (MoveNext())
                {
                    if (item.Equals(en.Current))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            using (IEnumerator<T> en = GetEnumerator())
            {
                while (MoveNext())
                {
                    array[arrayIndex++] = en.Current;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            using (IEnumerator<T> en = GetEnumerator())
            {
                while (MoveNext())
                {
                    if (en.Current.Equals(item))
                    {
                        return index;
                    }
                    ++index;
                }
            }
            return -1;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
            if (index == 0)
            {
                AppendFirst(value);
                return;
            }
            
            Node item = GetNode(index - 1);
            Node new_item = new Node(value, item._next);
            item._next = new_item;
            ++_count;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0) return false;
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                _head = _head._next;
                _count--;
                return;
            }

            int current_index = 0;
            Node temp = _head;

            using (IEnumerator<T> en = GetEnumerator())
            {
                while (MoveNext())
                {
                    if (current_index == index - 1)
                    {
                        temp = _currentItem; 
                    }

                    if (current_index == index)
                    {
                        temp._next = _currentItem._next;
                        --_count;
                        return;
                    }

                    ++current_index;
                }
            }
         
        }
        #endregion

        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region IEnumerator

        private Node _currentItem = null;

        public T Current { get => _currentItem._value; }

        object IEnumerator.Current { get => Current; }


        public bool MoveNext()
        {
            if (_currentItem == null)
                _currentItem = _head;
            else
                _currentItem = _currentItem._next;

            return _currentItem != null;
        }

        public void Reset()
        {
            _currentItem = null;
        }

        public void Dispose()
        {
            Reset();
        }
        #endregion
    }
}
