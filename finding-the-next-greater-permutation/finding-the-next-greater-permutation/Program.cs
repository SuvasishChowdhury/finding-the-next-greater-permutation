using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(PermutationStep(123));    // Output: 132
        Console.WriteLine(PermutationStep(12453));  // Output: 12534
        Console.WriteLine(PermutationStep(11121));  // Output: 11211
    }

    public static int PermutationStep(int num)
    {
        char[] digits = num.ToString().ToCharArray();

        // Step 1: Identify the pivot
        int k = -1;
        for (int i = digits.Length - 2; i >= 0; i--)
        {
            if (digits[i] < digits[i + 1])
            {
                k = i;
                break;
            }
        }

        // If no such index exists, return -1
        if (k == -1)
        {
            return -1;
        }

        // Step 2: Find the successor
        int l = -1;
        for (int i = digits.Length - 1; i > k; i--)
        {
            if (digits[i] > digits[k])
            {
                l = i;
                break;
            }
        }

        // Step 3: Swap the pivot and the successor
        Swap(ref digits[k], ref digits[l]);

        // Step 4: Reverse the suffix
        Array.Reverse(digits, k + 1, digits.Length - (k + 1));

        // Convert the array back to an integer and return it
        int result = int.Parse(new string(digits));
        return result;
    }

    private static void Swap(ref char a, ref char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }
}
