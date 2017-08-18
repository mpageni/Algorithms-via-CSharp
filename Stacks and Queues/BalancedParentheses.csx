using System.Collections;

/**
 The class function returns true if the parenthesis in the expression is balanced. 
 An expression parenthesis might include (,{,{,],},)
 eg, isBalanced("[()]{}{[()()]()}") returns true
 eg, isBalanced("[(])") returns false
 http://algs4.cs.princeton.edu/13stacks/
**/
public class Parenthesis
{
    public static readonly char LEFT_PAREN = '(';
    public static readonly char RIGHT_PAREN = ')';
    public static readonly char LEFT_BRACE = '{';
    public static readonly char RIGHT_BRACE = '}';
    public static readonly char LEFT_BRACKET = '[';
    public static readonly char RIGHT_BRACKET = ']';

    public static bool isBalanced(string expression)
    {
        Stack<char> s = new Stack<char>();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == LEFT_PAREN) s.Push(LEFT_PAREN);
            if (expression[i] == LEFT_BRACE) s.Push(LEFT_BRACE);
            if (expression[i] == LEFT_BRACKET) s.Push(LEFT_BRACKET);
            
            if(expression[i] == RIGHT_PAREN){
                if(s.Count == 0) return false;
                if(s.Pop() != LEFT_PAREN) return false;
            }
            else if(expression[i] == RIGHT_BRACE){
                if(s.Count == 0) return false;
                if(s.Pop()!= LEFT_BRACE) return false;
            }
            else if(expression[i] == RIGHT_BRACKET){
                if(s.Count == 0 ) return false;
                if(s.Pop() != LEFT_BRACKET) return false;
            }                      
        }
        return s.Count == 0;
    }
    
    //Test Client
    public static void Test(string expression)
    {
        Console.WriteLine(isBalanced(expression));
    }    
}

Parenthesis.Test("(manod[j)");
Parenthesis.Test("[()]{}")
