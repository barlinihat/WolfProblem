using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Xml.Linq;

public class WolfProblem
{
    public static List<int> duplicates(int[] arr, int n)
    {
        for (int i = 0; i < n; i++)
        {
            arr[i] += 1;
        }

        List<int> res = new List<int>();
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            //Calculate index value
            int index = Math.Abs(arr[i]) > n ? Math.Abs(arr[i]) / (n + 1) : Math.Abs(arr[i]);

            if (index == n)
            {
                count++;
                continue;
            }

            int val = arr[index];

            // Check if element value is negative, positive
            // or greater than n
            if (val < 0)
            {
                res.Add(index - 1);
                arr[index] = Math.Abs(arr[index]) * (n + 1);
            }
            else if (val > n)
                continue;
            else
                arr[index] = -1 * arr[index];
        }

        //If largest element occurs more than once
        if (count > 1)
            res.Add(n - 1);

        if (res.Count == 0)
            res.Add(-1);
        else
            res.Sort();

        return res;
    }

    public static void Main(string[] args)
    {
        int enterArrLength = 0;
        long enterValue = 0;
        string convertEnterValue;

        Console.Write("Enter array length : ");
        enterArrLength = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value : ");
        enterValue = Convert.ToInt64(Console.ReadLine());

        convertEnterValue = Convert.ToString(enterValue);

        int[] numRay = new int[enterArrLength];
        numRay = convertEnterValue.ToArray().Select(c => (int)char.GetNumericValue(c)).ToArray();

        if (numRay.Length == enterArrLength)
        {
            int n = numRay.Length;
            List<int> ans = duplicates(numRay, n);
            int mostCommonSmallestId = ans.Min();
            Console.WriteLine(mostCommonSmallestId);
        }
        else
        {
            Console.WriteLine("you must enter data of the desired length");
        }
    }
}
