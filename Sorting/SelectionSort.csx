// Time Complexity is (N-1) + (N-2) + (N-3) ...... + 1 + 0  ~ N^2
// Quadratic time, goes through all elements to do the sort.

public class Selection
{

    public static void sort(IComparable[] a)
    {
        int N = a .Length;
        for(int i=0; i<N; i++)
            {
                int min = i;
                for(int j = i+1; j < N; j++)
                    if(less(a[j],a[min]))
                        min = j;                       
                exch(a, i , min);
            }    
    }

    private static bool isSorted(IComparable[] a)
    {
        for (int i = 1; i < a.Length; i++)
            if (less(a[i], a[i - 1]))
                return false;
        return true;
    }

    private static bool less(IComparable p, IComparable q)
    {
        return p.CompareTo(q) < 0;
    }

    private static void exch(IComparable[] a, int p, int q)
    {
        IComparable swap = a[p];
        a[p] = a[q];
        a[q] = swap;
    }   
}

//Test code
IComparable[] a = new IComparable[] {1, 5, 6, 3, 9, 2};
Selection.sort(a);
for(int i = 0; i < a.Length; i++)
    Console.Write( a[i] + " ");
