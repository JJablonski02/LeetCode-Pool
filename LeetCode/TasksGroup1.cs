using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TasksGroup1
    {
        /*
        Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        You may assume that each input would have exactly one solution, and you may not use the same element twice.
        You can return the answer in any order.
        Example 1:

        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
        Example 2:

        Input: nums = [3,2,4], target = 6
        Output: [1,2]
        Example 3:

        Input: nums = [3,3], target = 6
        Output: [0,1]
            */

        ///SOLUTION///

        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                    for (int j = i + 1; j < nums.Length; j++)
                        if (nums[i] + nums[j] == target)
                            return new int[] { i, j };
                return new int[] { };
            }
        }

        /*Given an integer x, return true if x is a
        palindrome, and false otherwise.*/

        ///SOLUTION///
        
        public class Solution2
        {
            public bool IsPalindrome (int x)
            {
                var y = x.ToString().ToCharArray();
                Array.Reverse(y);
                return x.ToString() == new string(y);
            }
        }

        //Without converting to string
        public class Soluton3
        {
            public bool IsPalindrome (int x)
            {
                int y = 0, z = x;
                while(z > 0)
                {
                    y = y * 10 + z % 10;
                    z /= 10;
                }
                return y == x;
            }
        }

    }
}

