using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    public static class Arrays
    {
        public enum Approach
        {
            Brute,
            Better,
            Optimal
        }
        #region SubarrayWithGivenSum
        public static List<int> SubarrayWithGivenSum(int[] arr, int n, int s)
        {
            //code here
            int right = 0;
            int left = 0;
            int currentSum = 0;
            List<int> result = new List<int>();

            //edge case
            if (s == 0)
            {
                result.Add(-1);
                return result;
            }

            while (right < n)
            {

                while (currentSum < s)
                { 
                    //edge case
                    if(right==n && currentSum<s) {
                        result.Add(-1);
                        return result;
                    }

                    currentSum += arr[right];
                    right++;
                    
                }
                while (currentSum > s)
                {
                    currentSum -= arr[left];
                    left++;

                }
                if (currentSum == s)
                {
                    result.Add(left + 1); result.Add(right); return result;

                }

            }
            result.Add(-1);
            return result;
        }
        #endregion

        # region 1 Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {

            int[] result = new int[2];
            bool foundTarget = false;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        foundTarget = true;
                        break;
                    }
                    
                }
                if (foundTarget) break;
            }
            return result;
        }
        #endregion
    }
}
