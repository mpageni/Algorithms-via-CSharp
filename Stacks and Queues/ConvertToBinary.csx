//The following snippet prints a binary representation of a given number using stack
//More info at: http://algs4.cs.princeton.edu/13stacks/

public static void PrintBinary(int n)
{
    Stack<int> s = new Stack<int>();
    while(n > 0)
    {
        s.Push(n%2);
        n = n/2;
    }   
    while(!(s.Count == 0))
        Console.Write(s.Pop());    
}
//Test
PrintBinary(50);
