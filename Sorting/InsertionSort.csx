// Time Complexity  ~ N^2
// Best case N-1 comparistion, 0 exchanges
// Worst case (N^2)/2 compares and (N^2)/2 exchanges
// Time complexity is Linear for partially sorted arrays.

public class Insertion
{
    public static void sort(IComparable[] a)
    {
       int N = a.Length;
       for(int i = 0; i < N; i++)
       {
            for(int j = i; j > 0; j--)
            {
                if(less(a[j],a[j-1]))
                    exch(a,j,j-1);
                else
                    break;
            }       
       }                  
    }
        
    private static bool less(IComparable a, IComparable b)
    {
        return a.CompareTo(b) < 0;    
    }
    
    private static void exch(IComparable[] a, int p, int q)
    {
        IComparable swap = a[p];
        a[p] = a[q];
        a[q] = swap;             
    }
    
    private static bool isOrdered(IComparable[] a)
    {
        for(int i = 1; i < a.Length; i++)
            if(less(a[i],a[i-1]))
                return false;

        return true;       
    }   
}

//Test code
IComparable[] a = new IComparable[] {1, 5, 6, 3, 9, 2};
Insertion.sort(a);
foreach(int i in a)
    Console.Write( i + " ");
