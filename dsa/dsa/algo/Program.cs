using NUnit.Framework;
using System;

namespace algo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //TestLinkedList();
            //TestBST();
            InserteRecordsAndShowCount();


        }

        static void InserteRecordsAndShowCount()
        {
            Random r = new Random();
            DS.BST bst = new DS.BST();
            int i = 0;
            int till = 10000;
            while (i++ < till)
            {
               int val= r.Next(0, 11);
                bst.Insert(val);
            }

            bst.InOrderTraversal();
        }

        static void TestBST()
        {
            DS.BST bst = new DS.BST();
            bst.Insert(5);
            bst.Insert(2);
            bst.Insert(8);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(1);

            Assert.IsTrue(bst.KeyExists(5));
            Assert.IsTrue(bst.KeyExists(2));
            Assert.IsTrue(bst.KeyExists(10));
            Assert.IsTrue(bst.KeyExists(1));

            bst.InOrderTraversal();
            Console.WriteLine("--");
            bst.PreOrderTravel();
            Console.WriteLine("--");
            bst.PostOrderTraversal();
            Assert.AreEqual(1, bst.FindMin());
            Assert.AreEqual(10, bst.FindMax());

            bst.InOrderTraversal();
            bst.RemoveNode(5);
            Console.WriteLine("--");
            bst.InOrderTraversal();
            bst.RemoveNode(1);
            Console.WriteLine("--");
            bst.InOrderTraversal();
            bst.RemoveNode(6);
            Console.WriteLine("--");
            bst.InOrderTraversal();
            bst.RemoveNode(8);
            Console.WriteLine("--");
            bst.InOrderTraversal();
            bst.RemoveNode(5);
            Console.WriteLine("--");
            bst.InOrderTraversal();
            bst.RemoveNode(10);
            Console.WriteLine("--");
            bst.InOrderTraversal();
            bst.RemoveNode(8);
            Console.WriteLine("--");
            bst.InOrderTraversal();

        }

        static void TestLinkedList()
        {
            DS.LinkedList list = new DS.LinkedList();
            list.Insert("one", "header");
            list.Insert("two", "one");
            list.Insert("three", "one");
            list.Remove("one");
        }

        static void TestFib()
        {
            DP.fibonacchi fn = new DP.fibonacchi();
            Console.WriteLine(fn.GetFibonachiByRecursion_BAD(5));
            Console.WriteLine(fn.GetFibonachiByRecursion_BAD(8));
            Console.WriteLine(fn.GetFibonachiByRecursion_BAD(10));
            Console.WriteLine(fn.GetFibonachiByRecursion_BAD(25));
            //Console.WriteLine(fn.GetFibonachiByRecursion_BAD(50));

            Console.WriteLine(fn.GetFibonachiByRecursion_Memoization(5));
            Console.WriteLine(fn.GetFibonachiByRecursion_Memoization(8));
            Console.WriteLine(fn.GetFibonachiByRecursion_Memoization(10));
            Console.WriteLine(fn.GetFibonachiByRecursion_Memoization(25));
            Console.WriteLine(fn.GetFibonachiByRecursion_Memoization(50));
            Console.WriteLine(fn.GetFibonachiByRecursion_Memoization(80));

            Console.WriteLine("fib naive");
            Console.WriteLine(fn.GetFibonachiNaive(5));
            Console.WriteLine(fn.GetFibonachiNaive(8));
            Console.WriteLine(fn.GetFibonachiNaive(10));
            Console.WriteLine(fn.GetFibonachiNaive(25));
            Console.WriteLine(fn.GetFibonachiNaive(50));
            Console.WriteLine(fn.GetFibonachiNaive(80));
        }

        static void TestRPN()
        {
            RPN.RPN r = new RPN.RPN();
            Console.WriteLine(r.GeneratePostfixFromInfix("a+b*(c-d)"));
            Console.WriteLine(r.GeneratePostfixFromInfix("f=a*c^k/p-q*g^(h-b)"));
            Console.WriteLine(r.GeneratePostfixFromInfix("f=a/c^k*p-q*g^(h-b)"));



            Console.WriteLine(r.SolveRPN(new string[] { "2", "1", "+", "3", "*" }));
            Console.WriteLine(r.SolveRPN(new string[] { "4", "13", "5", "/", "+" }));
            Console.WriteLine(r.SolveRPN(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }));
        }
    }
}