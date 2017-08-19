//Binary search implementation in c#
//Provides static recursive and non recursive methods
//Assumes the int array is sorted.
//Time complexity O(LgN)
//Space complexity differs

public class BinarySearch
{
    //Recursive Approach
    public static int recursiveIndexOf(int[] a, int key, int low, int high)
    {     
        if(low <= high){
            int mid = low + (low + high)/2;
            if(key < a[mid]) return recursiveIndexOf(a,key,low,mid-1);
            else if(key > a[mid]) return recursiveIndexOf(a, key, mid+1,high);
            else return mid;
        }        
        return -1;           
    }

    //Iterative Approach
    public static int indexOf(int[] a, int key)
    {
        int low = 0;
        int high = a.Length - 1;
        while(low <= high){
            int mid = low + (low + high)/2;
            if(key < a[mid]) high = mid - 1;
            else if(key > a[mid]) low = mid + 1;
            else return mid;
        }        
        return -1;   
    }

}

//Test
int[] a = new int[]{1,3,5,6,9,2,4};
Console.WriteLine("3 found at " + BinarySearch.recursiveIndexOf(a, 3, 0, a.Length));
Console.WriteLine("3 found at " + BinarySearch.indexOf(a,3));
Console.WriteLine("6 found at " + BinarySearch.indexOf(a,6));
