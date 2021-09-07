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
        }
    }
}
