using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class LinkedList<T>
    {
        private class Node()
        {
            public required T Value { get; init; }
            public LinkedList<T>.Node? NextNode { get; set; } = null;
        }

        private LinkedList<T>.Node? Head;

        public int Length { get; set; } = 0;

        public void AddTail(T value)
        {
            LinkedList<T>.Node node = new LinkedList<T>.Node() { Value = value };
            if (Head == null)
            {
                this.Head = node;
            }
            else
            {
                LinkedList<T>.Node? current = this.Head;
                while (current.NextNode != null)
                {
                    current = current.NextNode;
                }
                current.NextNode = node;
            }
            this.Length++;
        }

        public void AddHead(T value)
        {
            LinkedList<T>.Node node = new LinkedList<T>.Node() { Value = value };
            if (Head == null)
            {
                this.Head = node;
            }
            else
            {
                node.NextNode = this.Head;
                this.Head = node;
            }
            this.Length++;
        }

        public T Value(int index)
        {
            //if (Head != null)
            //{
            //    LinkedList<T>.Node current = this.Head;

            //    for (int i = 0; i < index; i++)
            //    {
            //        if (current.NextNode != null)
            //        {
            //            current = current.NextNode;
            //        }
            //        else
            //        {
            //            throw new IndexOutOfRangeException();
            //        }
            //    }
            //    return current.Value;
            //}
            //else
            //{
            //    throw new IndexOutOfRangeException();
            //}
            if (Head == null)
            {
                throw new IndexOutOfRangeException();
            }
            LinkedList<T>.Node current = this.Head;
            for (int i = 0; i < index; i++)
            {
                if (current != null && current.NextNode != null)
                {
                    current = current.NextNode;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            return current.Value;
        }

        public override string ToString()
        {
            if (Head == null)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            LinkedList<T>.Node current = this.Head;

            for (int i = 0; i < Length; i++)
            {
                sb.Append($"{current.Value} ");
                if (current.NextNode != null)
                {
                    current = current.NextNode;
                }
            }
            return sb.ToString();
        }
    }
}
