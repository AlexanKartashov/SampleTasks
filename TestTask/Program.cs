using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sub = new int[] { 1,6,7,23};

            int[] orig = new int[] {1,6};

            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig));

            Console.ReadLine();
        }
    }
}

namespace SampleTasks
{
    public static class SampleUtilities
    {
        public static bool SubArrayIsInArray(int[] subArray, int[] array)
        {
            if ((array.Length == 0) & (subArray.Length != 0))
                return false;

            if (subArray.Length == 0)
                return true;            
            
            var matchFound = false;
            var j = 0;
            for(var i=0;i<array.Length;i++)
            {
                if (!matchFound)
                {
                    if (array[i] == subArray[0])
                    {
                        matchFound = true;
                    }
                }
                else
                {
                    j++;
                    if (subArray.Length == (j+1))
                    {
                        if (array[i] == subArray[j])
                            return true;
                        else
                        {
                            matchFound = false;
                            j = 0;
                        }
                    }
                    else
                    {
                        if (array[i] != subArray[j])
                        {
                            matchFound = false;
                            j = 0;
                        }
                    }
                }
            }
            return false;
        }
    }
}