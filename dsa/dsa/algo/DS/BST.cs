using System;
using System.Collections.Generic;
using System.Text;

namespace algo.DS
{
    class BSTNode
    {
        internal int Key { get; set; }
        internal BSTNode Left;
        internal BSTNode Right;
    }
    public class BST
    {
        BSTNode root;
        public BST()
        {
            root = null;
        }

        public void Insert(int val)
        {
            BSTNode nNode = new BSTNode();
            nNode.Key = val;
            if (root == null)
            {
                root = nNode;
                return;
            }
            
            BSTNode current = new BSTNode();
            BSTNode parent = new BSTNode();
            current = root;
            while (true)
            {
                parent = current;
                if (val < parent.Key)
                {
                    current = current.Left;
                    if (current == null)
                    {
                        parent.Left = nNode;
                        return;
                    }
                }
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = nNode;
                        return;
                    }
                }
            }
        }

        public bool KeyExists(int key)
        {
            return KeyExists(key, root);
        }

        private bool KeyExists(int key,BSTNode Node)
        {
            if (Node.Key == key) return true;
            if (Node == null) return false;
            if(key<Node.Key) return KeyExists(key, Node.Left);
            return KeyExists(key, Node.Right);
            
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }

        private void InOrderTraversal(BSTNode Node)
        {
            if (Node != null)
            {
                InOrderTraversal(Node.Left);
                Console.WriteLine(Node.Key);
                InOrderTraversal(Node.Right);
            }
        }
    }

}
