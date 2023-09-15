using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

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
            public bool IsPalindrome(int x)
            {
                var y = x.ToString().ToCharArray();
                Array.Reverse(y);
                return x.ToString() == new string(y);
            }
        }

        //Without converting to string
        public class Solution3
        {
            public bool IsPalindrome(int x)
            {
                int y = 0, z = x;
                while (z > 0)
                {
                    y = y * 10 + z % 10;
                    z /= 10;
                }
                return y == x;
            }
        }
        /*Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

            Symbol       Value
            I             1
            V             5
            X             10
            L             50
            C             100
            D             500
            M             1000

            For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

            Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

                I can be placed before V (5) and X (10) to make 4 and 9. 
                X can be placed before L (50) and C (100) to make 40 and 90. 
                C can be placed before D (500) and M (1000) to make 400 and 900.

            Given a roman numeral, convert it to an integer.
            */

        public class Solution4
        {

            static Dictionary<char, int> romanDigits = new()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            public int RomanToInt(string s)
            {
                var result = 0;
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (romanDigits[s[i]] < romanDigits[s[i + 1]])
                        result -= romanDigits[s[i]];
                    else
                        result += romanDigits[s[i]];
                }

                return result + romanDigits[s[s.Length - 1]];
            }
        }

        /*Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

        Each letter in magazine can only be used once in ransomNote.*/

        public class Solution5
        {
            public bool CanConstruct(string ransomNote, string magazine)
            {
                int[] array = new int[26];
                foreach (char charecter in magazine)
                {
                    array[(int)charecter - 97]++;
                }

                foreach (char charecter in ransomNote)
                {
                    if (array[(int)charecter - 97] == 0)
                    {
                        return false;
                    }

                    array[(int)charecter - 97]--;
                }

                return true;
            }
        }

        /*Given a string s, find the length of the longest 
            substring
             without repeating characters.

 

        Example 1:

        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.
        Example 2:

        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.
        Example 3:

        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

        Constraints:

        0 <= s.length <= 5 * 104
        s consists of English letters, digits, symbols and spaces.
         */

        public class Solution6
        {
            public int LengthOfLongestSubstring(string s)
            {
                int[] dict = new int[256];
                Array.Fill(dict, -1);
                int maxLen = 0, start = -1;
                for (int i = 0; i < s.Length; i++)
                {
                    start = Math.Max(start, dict[s[i]]);
                    maxLen = Math.Max(maxLen, i - start);
                    dict[s[i]] = i;
                }
                return maxLen;
            }
        }

        /*
         Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

            An input string is valid if:

            Open brackets must be closed by the same type of brackets.
            Open brackets must be closed in the correct order.
            Every close bracket has a corresponding open bracket of the same type.
 

            Example 1:

            Input: s = "()"
            Output: true
            Example 2:

            Input: s = "()[]{}"
            Output: true
            Example 3:

            Input: s = "(]"
            Output: false
 

            Constraints:

            1 <= s.length <= 104
            s consists of parentheses only '()[]{}'.
            */

        public class Solution7
        {
            public bool IsValid(string s)
            {
                while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
                {
                    s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
                }
                return s.Length == 0;

            }
        }

        public class Solution8
        {
            public bool IsValid(string s)
            {
                Dictionary<char, char> bracketsMap = new Dictionary<char, char>
                {
                    {'{',  '}'},
                    {'(',  ')'},
                    {'[',  ']'},
                };
                Stack<char> openBrackets = new Stack<char>();

                foreach (char bracket in s)
                {
                    if (bracketsMap.ContainsKey(bracket))
                    {
                        openBrackets.Push(bracket);
                    }
                    else
                    {
                        if (openBrackets.Count == 0)
                        {
                            return false;
                        }
                        if (bracketsMap[openBrackets.Pop()] == bracket)
                        {
                            continue;
                        };
                        return false;
                    }
                }
                return openBrackets.Count == 0;
            }
        }
        
        public class Solution9
        {
            public int MaxProfit(int[] prices)
            {
                int minPrice = int.MaxValue;
                int maxProfit = 0;

                for (int i = 0; i < prices.Length; i++)
                {
                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i];
                    }

                    int profit = prices[i] - minPrice;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }

                return maxProfit;
            }
        }

        public class Solution10
        {
            public bool isPalindrome(string input)
            {
                char[] chars = input.ToString().ToCharArray();

                Array.Reverse(chars);

                return input == new string(chars);
            }
        }
    }
}

