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
                    //check stack size. If open bracket found, push it without checking precedence.
                    if (operatorStack.Count == 0 || l1 == '(')
                    {
                        operatorStack.Push(l1);
                        continue;
                    }

                    //If close bracket found, pop everything untill open bracket is found.
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
                        //check precedence. If higher, just add it to stack.
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

            //empty stack and write all to expression.
            while (operatorStack.Count != 0)
            {
                postfix += operatorStack.Pop();
            }
            return postfix;
        }
        
        public int SolveRPN(string[] tokens)
        {
            string[] operators = new string[]{"+","-","*","/"};
        Stack<int> valStack = new Stack<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (Array.IndexOf(operators, tokens[i]) == -1)
                {
                    valStack.Push(getInt(tokens[i]));
                }
                else
                {
                    var op = tokens[i];
                    int v1 = valStack.Pop();
                    int v2 = valStack.Pop();
                    var val = Eval(op, v2, v1);
                    valStack.Push(val);
                }
            }
            return Convert.ToInt32(valStack.Pop());
        }

        private int Eval(string op, int a, int b)
        {
            switch (op)
            {
                case "+":
                    return a+b;
                case "*":
                    return a * b;
                case "-":
                    return a - b;
                case "/":
                    return a / b;
                default:
                    return 0;
            }
        }

        private int getInt(string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
