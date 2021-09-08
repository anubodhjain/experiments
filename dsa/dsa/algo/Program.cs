using System;

namespace algo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RPN.RPN r = new RPN.RPN();
            Console.WriteLine(r.GeneratePostfixFromInfix("a+b*(c-d)"));
            Console.WriteLine(r.GeneratePostfixFromInfix("f=a*c^k/p-q*g^(h-b)"));

            Console.WriteLine(r.SolveRPN(new string[] { "2", "1", "+", "3", "*" }));
            Console.WriteLine(r.SolveRPN(new string[] { "4", "13", "5", "/", "+" }));
            Console.WriteLine(r.SolveRPN(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }));
        }
    }
}
