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
        internal int Count;
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
                        parent.Count++;
                        return;
                    }
                }
                else if(val > parent.Key)
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = nNode;
                        parent.Count++;
                        return;
                    }
                }
                else
                {
                    parent.Count++;
                    return;
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
            int edgeCount = -1;
            InOrderTraversal(root,ref edgeCount);
            Console.WriteLine("edgecount=" + edgeCount);
        }

        public void PreOrderTravel()
        {
            PreOrder(root);
        }

        public void PostOrderTraversal()
        {
            PostOrder(root);
        }

        private void PostOrder(BSTNode Node)
        {
            if (Node != null)
            {
                PostOrder(Node.Left);
                PostOrder(Node.Right);
                Console.WriteLine(Node.Key);
            }
        }

        private void PreOrder(BSTNode Node)
        {
            if (Node != null)
            {
                Console.WriteLine(Node.Key);
                PreOrder(Node.Left);
                PreOrder(Node.Right);
            }
        }

        private void InOrderTraversal(BSTNode Node, ref int edgeCount)
        {
            if (Node != null)
            {
                edgeCount++;
                InOrderTraversal(Node.Left, ref edgeCount);
                Console.WriteLine(Node.Key+",count="+Node.Count);
                InOrderTraversal(Node.Right, ref edgeCount);
            }
        }

        public int FindMin()
        {
            BSTNode current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Key;
        }

        public int FindMax()
        {
            BSTNode current = root;
            while (current.Right != null)
            {
               current = current.Right;
            }
            return current.Key;
        }

        public void RemoveNode(int val)
        {
            BSTNode toDelete = new BSTNode();
            toDelete.Key = val;

            BSTNode current = root;
            BSTNode parent=current;
            bool isLeft = false;
            while (current.Key != val)
            {
                parent = current;
                if (val < current.Key)
                {
                    current = current.Left;
                    isLeft = true;
                }
                else
                {
                    current = current.Right;
                    isLeft = false;
                }
            }
            
            //Leaf
            if (current.Left == null && current.Right == null)
            {
                if (current == root)
                    root = null;
                if (isLeft)
                    parent.Left = null;
                else
                    parent.Right = null;
            }

            //single child - left
            else if (current.Right == null && current.Left != null)
            {
                if (current == root)
                    root = current.Left;
                else if (isLeft)
                    parent.Left = current.Left;
                else
                    parent.Right = current.Right;
            }

            //single child - right
            else if (current.Left == null && current.Right != null)
            {
                if (current == root)
                    root = current.Right;
                else if (isLeft)
                    parent.Left = current.Left;
                else
                    parent.Right = current.Right;
            }

            //both child
            else
            {
                BSTNode sucessor = GetSuccessor(current);
                if (current == root)
                    root = sucessor;
                else if (isLeft)
                    parent.Left = sucessor;
                else
                    parent.Right = sucessor;

                sucessor.Left = current.Left;
            }

            return;
        }

        private BSTNode GetSuccessor(BSTNode node)
        {
            BSTNode successorParent = node;
            BSTNode current = node.Right;
            BSTNode successor = current;

            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.Left;
            }

            if(successor != node.Right)
            {
                successorParent.Left = successor.Right;
                successor.Right = node.Right;
            }
            return successor;
        }
    }

}
