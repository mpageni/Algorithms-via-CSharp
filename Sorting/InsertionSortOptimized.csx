//Optimized insertion sort using sentinel.
// http://algs4.cs.princeton.edu/20sorting/

public class InsertionSortOptimized
{

    public static void sort(IComparable[] a)
    {

        int N = a.Length;
        int exchanges = 0;
        //Put the min value at first, so we avoid comparision letter for index out of bounds
        for (int i = N - 1; i > 0; i--)
        {
            if (less(a[i], a[i - 1]))
            {
                exch(a, i, i - 1);
                exchanges++;
            }
        }
        
        if(exchanges == 0) return;

        //Since min is at the front....
        for (int i = 2; i < N; i++)
        {
            IComparable val = a[i];
            while (less(a[i], a[i - 1]))
            {
                exch(a, i, i - 1);
                i--;
            }
            a[i] = val;
        }


    }

    public static bool isOrdered(IComparable[] a)
    {
        for (int i = a.Length; i > 0; i--)
            if (less(a[i], a[i - 1]))
                return false;

        return true;
    }

    public static bool less(IComparable a, IComparable b)
    {
        return a.CompareTo(b) < 0;
    }

    public static void exch(IComparable[] a, int p, int q)
    {
        IComparable swap = a[p];
        a[p] = a[q];
        a[q] = swap;
    }

}
//Test code
IComparable[] a = new IComparable[] { 1, 5, 6, 3, 9, 2 };
InsertionSortOptimized.sort(a);
foreach (int i in a)
    Console.Write(i + " ");
