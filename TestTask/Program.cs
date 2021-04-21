using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sub = new int[] { 1,2,3,4};
            int[] orig = new int[] {1,2};
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); //false

            sub = new int[] { 1, 2, 3, 4 };
            orig = new int[] { 1, 2 , 4, 3, 5};
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // false

            sub = new int[] { 1, 2, 3, 4 };
            orig = new int[] { 1, 2, 3 };
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // false

            sub = new int[] { 1, 2, 3, 4 };
            orig = new int[] { };
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // false

            sub = new int[] { 1, 2, 3 };
            orig = new int[] { 5,4,1,2};
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); //false

            sub = new int[] { 1, 2, 3 };
            orig = new int[] { 1, 2, 4, 3, 5, 1, 2, 6 };
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // false

            sub = new int[] { };
            orig = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // true

            sub = new int[] { 1, 2, 3 };
            orig = new int[] { 1, 2, 4, 4, 5, 1,2,3,6 };
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // true

            sub = new int[] { 1, 2, 3 };
            orig = new int[] { 1, 2, 3, 1, 2 };
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // true

            sub = new int[] { 1, 2, 3 };
            orig = new int[] {5, 4, 1, 2, 3, 6, 7 };
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // true

            sub = new int[] { 1, 2, 3 };
            orig = new int[] { 5, 4, 1, 2, 3};
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // true

            sub = new int[] { 1, 2, 3 };
            orig = new int[] { 1, 2, 3 };
            Console.WriteLine(SampleTasks.SampleUtilities.SubArrayIsInArray(sub, orig)); // true

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