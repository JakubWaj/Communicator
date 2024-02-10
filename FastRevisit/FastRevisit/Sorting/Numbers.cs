namespace FastRevisit.Sorting;

public static class Numbers
{

    public static int[] getData(int n,int seed=0)
    {
        Random rand = new Random(seed==0 ? Guid.NewGuid().GetHashCode() : seed.GetHashCode());
        int[] result = new int[n];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = rand.Next(0, n * 10);
        }
        return result;
    }
}