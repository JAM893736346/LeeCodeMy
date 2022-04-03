using System;

namespace LeeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                int[] a = new int { };
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; i++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            a[0] = i; a[1] = j;
                        }
                    }
                }
                return a;
            }
        }
    }

}
