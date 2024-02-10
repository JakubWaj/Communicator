namespace FastRevisit.Sorting;

public static class SelectionSort
{
    public static int[] Sort(int[] arr)
    {
        int i, j, index;

        for (i = 0; i < arr.Length - 1; i++)
        {
            index = i;
            for (j = i+1; j < arr.Length; j++)
            {
                if (arr[j]<arr[index])
                {
                    index = j;
                }

                if (index!=i)
                {
                    (arr[i], arr[index]) = (arr[index], arr[i]);
                }
            }
        }
        
        return arr;
    }
}