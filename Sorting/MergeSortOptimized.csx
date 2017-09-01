// Optimized Mergesort
// Uses Insertion sort for small subarrays determined by CUTOFF

public class MergeSortOptimized
{
    public const int CUTOFF = 7;
    
    public static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
    {
        for (int k = lo; k <= hi; k++)
            aux[k] = a[k];

        int i = lo; int j = mid + 1;
        for (int k = lo; k <= hi; k++)
        {
            if (i > mid)                a[k] = aux[j++];
            else if (j > hi)            a[k] = aux[i++];
            else if (less(a[i], a[j]))  a[k] = aux[i++];
            else                        a[k] = aux[j++];
        }
    }

    public static void sort(IComparable[] a, IComparable[] aux, int lo, int hi)
    {
        //Perform insertion sort for smaller chunks
        if(hi <= lo + CUTOFF)
        {
            insertionSort(a);
            return;
        }        
        int mid = lo + (hi - lo) / 2;
        //return if already sorted
        if(less(a[mid+1],a[mid]))
            return;
        
        sort(a, aux, lo, mid);
        sort(a, aux, mid + 1, hi);
        merge(a, aux, lo, mid, hi);
    }

    public static void sort(IComparable[] a)
    {
       IComparable[] aux = new IComparable[a.Length];
       sort(a,aux,0,a.Length-1);

    }

    //Insertionsort for small subarrays
    public static void insertionSort(IComparable[] a)
    {
        int N = a.Length;
        for(int i = 0;i < N;i++)
        {
            int min = i;
             for(int j = i; j > 0; j--)
                {
                    if(less(a[j],a[j-1]))
                        exch(a, j, j-1);
                    else    
                        break;
                }                   
        }       
    }

    public static void exch(IComparable[] a, int p, int q)
    {
        IComparable swap = a[p];
        a[p] = a[q];
        a[q] = swap;    
    }

    public static bool less(IComparable a, IComparable b)
    {
        return a.CompareTo(b) < 0;
    }
}

//Test code
IComparable[] a = new IComparable[] { 1, 5, 6, 3, 9, 2 };
MergeSortOptimized.sort(a);
foreach (int i in a)
    Console.Write(i + " ");
