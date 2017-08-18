// This snippet prints the postfix equivalent for a given infix expression
// https://en.wikipedia.org/wiki/Infix_notation
// http://algs4.cs.princeton.edu/13stacks/
// Example  ( 2 + ( ( 3 + 4 ) * ( 5 * 6 ) ) ) prints 2 3 4 + 5 6 * * + 

public static string ConverToPostFix(string infixExpression)
{
    Stack<char> s = new Stack<char>();
    
    for(int i =0; i < infixExpression.Length; i++)
    {
        if(infixExpression[i] == '*')   s.Push('*');
        else if(infixExpression[i] == '/')   s.Push('/');
        else if(infixExpression[i] == '+')   s.Push('+');
        else if(infixExpression[i] == '-')   s.Push('-');
        else if(infixExpression[i] == ')')  Console.Write(s.Pop());
        else if(infixExpression[i] != '(') Console.Write(infixExpression[i]);
        
    } 
    return string.Empty;
}
//Test
ConverToPostFix("(a+b)/c)");
