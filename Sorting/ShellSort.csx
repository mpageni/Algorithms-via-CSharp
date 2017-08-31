// Time Complexity  ~  N^(3/2)
// http://algs4.cs.princeton.edu/21elementary/
// This is non trivial ...


public class Shell
{
    public static void sort(IComparable[] a)
    {
        int N = a.Length;

        int h = 1;
        while (h < N / 3)
            h = 3 * h + 1;

        while (h >= 1)
        {        
            for (int i = h; i < N; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (less(a[j], a[j - h]))
                        exch(a, j, j - h);
                    else
                        break;
                }
            }
            h = h/3;
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
        for (int i = 1; i < a.Length; i++)
            if (less(a[i], a[i - 1]))
                return false;

        return true;
    }
}

//Test code
IComparable[] a = new IComparable[] { 1, 5, 6, 3, 9, 2 };
Shell.sort(a);
foreach (int i in a)
    Console.Write(i + " ");
