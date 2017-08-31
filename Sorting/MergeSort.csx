// The classic divide and conquer MergeSort
// Time Complexity is NLogN -- 6NLogN comparisions.
// http://algs4.cs.princeton.edu/20sorting/

using System.Diagnostics;

public class MergeSort
{
    public static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
    {
        //Validate invariant that the arrays are sorted in half.
        Debug.Assert(isSorted(a, lo, mid));
        Debug.Assert(isSorted(a, mid + 1, hi));
        //Copy the array into auxillary array.
        for (int k = lo; k <= hi; k++)
            aux[k] = a[k];

        //Perform merge
        int i = lo;
        int j = mid + 1;
        for (int k = lo; k <= hi; k++)
        {
            if (i > mid)                    a[k] = aux[j++];
            else if (j > hi)                a[k] = aux[i++];
            else if (less(aux[j], aux[i]))  a[k] = aux[j++];
            else                            a[k] = aux[i++];
        }

        Debug.Assert(isSorted(a, lo, hi));
    }


    public static void sort(IComparable[] a, IComparable[] aux, int lo, int hi)
    {
        if (hi <= lo) return;
        int mid = lo + (hi - lo) / 2;
        sort(a, aux, lo, mid);
        sort(a, aux, mid + 1, hi);
        merge(a, aux, lo, mid, hi);
    }


    public static void sort(IComparable[] a)
    {
        IComparable[] aux = new IComparable[a.Length];
        sort(a, aux, 0, a.Length - 1);
        Debug.Assert(isSorted(a));
    }

    public static bool isSorted(IComparable[] a, int lo, int hi)
    {
        for (int i = hi; i > lo; i--)
            if (less(a[i], a[i - 1]))
                return false;
        return true;
    }

    public static bool isSorted(IComparable[] a)
    {
        return isSorted(a, 0, a.Length - 1);
    }

    public static bool less(IComparable a, IComparable b)
    {
        return a.CompareTo(b) < 0;
    }
}

//Test code
IComparable[] a = new IComparable[] { 1, 5, 6, 3, 9, 2 };
MergeSort.sort(a);
foreach (int i in a)
    Console.Write(i + " ");
