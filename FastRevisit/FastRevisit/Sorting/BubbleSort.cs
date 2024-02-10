namespace FastRevisit.Sorting;

public static class BubbleSort
{
    public static int[] Sort(int[] arr)
    {
        int i,j;
        bool swapped;
        for (i = 0; i < arr.Length-1; i++)
        {
            swapped = false;
            for (j = 0; j < arr.Length-i-1; j++)
            {
                if (arr[j]>arr[j+1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    swapped = true;
                }

            }

            if (swapped==false)
            {
                break;
            }
        }

        return arr;
    }
}