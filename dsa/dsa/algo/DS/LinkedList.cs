using System;
using System.Collections.Generic;
using System.Text;

namespace algo.DS
{
    public class LinkedList
    {
        Node Header;
        public LinkedList()
        {
            Header = new Node("header");
            Header.Next = null;
        }

        private Node FindAfter(Object after)
        {
            Node current = new Node();
            current = Header;
            while(current.Data != after)
            {
                current = current.Next; 
            }

            return current;
        }

        private Node FindPrevious(Object before)
        {
            Node current = Header;
            while(current.Next.Data != before)
            {
                current = current.Next;
            }
            return current;
        }

        public void Insert(Object newNode, Object after)
        {
            Node newnode = new Node(newNode);
            Node afterrr = FindAfter(after);
            newnode.Next = afterrr.Next;
            afterrr.Next = newnode;
        }

         public void Remove(Object toRemove)
        {
            Node Before = FindPrevious(toRemove);
            if (Before.Next != null) { Before.Next = Before.Next.Next; }

        }
    }

    public class Node
    {
        public Object Data;
        public Node Next;
        public Node() { }
        public Node(Object obj)
        {
            Data = obj;
            Next = null;
        }
    }
}
