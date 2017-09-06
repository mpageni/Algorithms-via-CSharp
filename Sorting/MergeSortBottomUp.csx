//Bottom up MergeSort
//Merge Sort without recursion

public class MergeSortBottomUp
{

    public static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
    {

        for (int k = lo; k <= hi; k++)
            aux[k] = a[k];

        int i = lo;
        int j = mid + 1;

        for (int k = lo; k <= hi; k++)
        {
            if (i > mid) a[k] = aux[j++];
            else if (j > hi) a[k] = aux[i++];
            else if (less(aux[i], aux[j])) a[k] = aux[i++];
            else a[k] = aux[j++];
        }
    }


    public static void sort(IComparable[] a)
    {
        IComparable[] aux = new IComparable[a.Length];
        int N = a.Length;

        for (int size = 1; size < N; size = size * 2)
        {
            for(int lo=0; lo < N - size; lo= lo + size*2)
            {
               int mid = lo + size - 1;
               int hi = Math.Min(lo+size*2-1,N-1);
               merge(a, aux, lo, mid, hi);
            }
        }
    }



    public static void insertionSort(IComparable[] a)
    {
        int N = a.Length;
        for (int i = 0; i < N; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (less(a[j], a[j - 1]))
                    exch(a, j, j - 1);
            }
        }
    }


    public static bool isOrdered(IComparable[] a)
    {
        for (int j = a.Length - 1; j > 0; j--)
            if (less(a[j], a[j - 1]))
                return false;
        return true;
    }


    public static bool less(IComparable x, IComparable y)
    {
        return x.CompareTo(y) < 0;
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
MergeSortBottomUp.sort(a);
foreach (int i in a)
    Console.Write(i + " ");
