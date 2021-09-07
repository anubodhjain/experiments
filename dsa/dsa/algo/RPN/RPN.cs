using System;
using System.Collections.Generic;
using System.Text;

namespace algo.RPN
{
    /// <summary>
    /// Reverse Polish Notation
    /// </summary>
    class RPN
    {
        readonly Dictionary<char, int> operators = new Dictionary<char, int>
        {
            { '-', 1 },
            { '+', 1 },
            { '*', 2 },
            { '/', 2 },
            { '^', 3 },
            { '(', 0 },
            { ')', 0 },
            { '=',-1 }
        };
        public string GeneratePostfixFromInfix(string infix)
        {
            if (infix.Length == 0)
                return infix;

            Stack<char> operatorStack = new Stack<char>();
            string postfix = string.Empty;
            for(int i = 0; i < infix.Length; i++)
            {
                char l1=infix[i];
                if (operators.ContainsKey(l1))
                {
                    //check stack size
                    if (operatorStack.Count == 0 || l1 == '(')
                    {
                        operatorStack.Push(l1);
                        continue;
                    }
                    else if (l1 == ')')
                    {
                        while(operatorStack.Peek() != '(')
                        {
                            postfix += operatorStack.Pop();
                        }
                        operatorStack.Pop();
                    }
                    else
                    {
                        //check precedence.
                        char topOfStack = operatorStack.Peek();
                        if(operators[l1] > operators[topOfStack])
                        {
                            operatorStack.Push(l1);
                        }
                        else
                        {
                            //pop all lower precedence and append to string. Then push higher precedence operator.
                            while (operators[l1] <= operators[operatorStack.Peek()])
                            {
                                postfix += operatorStack.Pop();
                            }
                            operatorStack.Push(l1);
                        }
                    }
                }
                else
                    postfix += l1;
            }

            while (operatorStack.Count != 0)
            {
                postfix += operatorStack.Pop();
            }
            return postfix;
        }
    }
}
