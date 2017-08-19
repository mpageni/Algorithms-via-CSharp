// Algorithm question from Algorithms, Fourth Edition Sedgewick Excercise 1.3.9
// http://algs4.cs.princeton.edu/home/
// Write a program that takes from standard input an expression without left parentheses
// and prints the equivalent infix expression with the parentheses inserted.
// For example, given the input: 1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )
// your program should print ( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )
 
public static void FixParentheses(string expression)
{
    
    Stack<char> operatorStack = new Stack<char>();
    Stack<string> operandStack = new Stack<string>();
    
    for(int i =0; i < expression.Length; i++)
    {
        char c = expression[i];
        switch(c) {
        
            case '+':
            case '-':
            case '*':
            case '/':
                operatorStack.Push(c);
                break;
            
            case ')':
                var b = operandStack.Pop();
                var a = operandStack.Pop();
                var op = operatorStack.Pop();
                operandStack.Push(new StringBuilder().Append('(').Append(a).Append(op).Append(b).Append(')').ToString());
                break;
            
            case ' ':
                break;               
            //Assuming input is valid, the remaining should be numbers 0 .. 9
            default:
                operandStack.Push(c.ToString());
                break;        
        }
   
    }    
        Console.Write(operandStack.Pop());
}


//Test
FixParentheses("1+2 ) * 3 - 4 ) * 5 - 6 )) )");
