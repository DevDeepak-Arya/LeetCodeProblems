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

        # region 1 Two Sum - Easy
        public static int[] TwoSum(int[] nums, int target,Approach approach)
        {
            int[] result = new int[2];
            switch (approach)
            {
                case Approach.Brute:

                    bool foundTarget = false;

                    for (int i = 0; i < nums.Length; i++)
                    {
                        for (int j = i + 1; j < nums.Length; j++)
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
                    break;

                case Approach.Better:
                    //TC - nlogn
                    //order of result does not matter

                    Dictionary<int,int> keyValuePairs = new Dictionary<int,int>();
                    for(int i = 0; i < nums.Length; i++)
                    {
                        int requiredValue = target - nums[i];
                        if (keyValuePairs.ContainsKey(requiredValue))
                        {
                            result[0] = i;
                            result[1] = keyValuePairs[requiredValue];
                            break;
                        };

                        if (!keyValuePairs.ContainsKey(nums[i]))
                        {
                            keyValuePairs.Add(nums[i], i);
                        }
                    }
                    break;

                case Approach.Optimal:
                    //without use of Dictionary
                    //two pointer approach
                    //TC - nlogn
                    Array.Sort(nums);
                    int left = 0;
                    int right = nums.Length - 1;
                    while(left < right)
                    {
                       int sum = nums[left] + nums[right];
                        if (sum == target) {/* return true;*/  };
                        if(sum<target) left++;
                        else right--;
                    }
                   // return false;
                    break;

            }
            return result;
        }
        #endregion

        #region 26. Remove Duplicates from Sorted Array - Easy
        public static int RemoveDuplicates(int[] nums,Approach approach)
        {
            int result = 0;
            switch (approach)
            {
                
                case Approach.Brute:
                    //TC - NlogN+N
                    HashSet<int> l1 = new HashSet<int>();
                    foreach (int num in nums)
                    {
                        l1.Add(num);
                    }
                    int i = 0;
                    foreach (int val in l1)
                    {
                        nums[i] = val;
                        i++;

                    }
                    result= l1.Count;
                    break;

                case Approach.Better:
                    //does not exist
                    break;

                case Approach.Optimal:
                    //TC - N
                    //two pointers approach
                    int a = 0; 
                    for(int j = 1; j < nums.Length; j++)
                    {
                        if(nums[a] != nums[j])
                        {
                            nums[a+1] = nums[j];
                            a++;
                        }
                    }
                    result = a + 1;
                    break;

                default: break;
            }
        
            return result;
        }

        #endregion

        #region 35. Search Insert Position - Easy
        public static int SearchInsert(int[] nums, int target,Approach approach)
        {
            int result = 0;
            switch (approach)
            {
                case Approach.Brute:
                    for (int i = 0; i < nums.Length; i++)
                    {

                        if (nums[i] == target || nums[i] > target) { result = i; break; }
                        if (nums[i] < target && i == nums.Length - 1) { result = i + 1; break; }
                    }

                    break;

                case Approach.Better:
                    break;

                case Approach.Optimal:
                    break;

                default: break;

            }
            return result;
        }
        #endregion

        #region 66. Plus One - Easy
        public static int[] PlusOne(int[] digits,Approach approach)
        {
            
            switch (approach)
            {
                case Approach.Brute:
                    //wont work for very large value
                    long originalNumber=0;
                    for (int i = digits.Length - 1; i >= 0; i--)
                    {
                        originalNumber += digits[Math.Abs(i - (digits.Length - 1))] * (long)Math.Pow(10, i);
                    }
                    originalNumber=originalNumber + 1;
                    long resultArrayLength=originalNumber.ToString().Length;
                    long[] resultArr = new long[resultArrayLength];
                    int dig;
                    while (originalNumber>0)
                    {
                        dig=(int)(originalNumber % 10);
                        resultArr[resultArrayLength-1] =dig;
                        originalNumber = originalNumber / 10;
                        resultArrayLength--;
                    }
                    long y=resultArr.Length;
                    break;

                case Approach.Better:
                    int x = digits.Length - 1;
                    bool takeNewResult = false;
                    int[] newResult = new int[digits.Length + 1];
                    do
                    {
                        if (digits[x] != 9)
                        {
                            digits[x] = digits[x] + 1;
                            break;
                        }
                        else if (digits[x] == 9 && x != 0)
                        {
                            digits[x] = 0;
                            x--;
                        }
                        else if (digits[x] == 9 && x == 0)
                        {
                            digits[x] = 0;
                            digits.CopyTo(newResult, 1);
                            newResult[0] = 1;
                            takeNewResult = true;
                            break;

                        }
                    }
                    while (x>=0);
                    if (takeNewResult) return newResult;
                    return digits;
                    break;

                case Approach.Optimal:
                    break;

                default: break;

            }
            int[] resultArr1 = new int[3];
            return resultArr1;
        }
        #endregion

        #region 1752. Check if Array Is Sorted and Rotated - Easy
        public static bool Check(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums.Length - 1 && nums[i] > nums[i + 1])
                {
                    count++;
                }
                else if (i == nums.Length - 1 && nums[nums.Length - 1] > nums[0]) count++;

                if (count > 1) return false;
            }
            return true;
        }
        #endregion

        #region 189. Rotate Array - Easy
        public static void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            if (k < 0) k = k + nums.Length;
            if (k != 0)
            {
                reverse(nums, 0, nums.Length - 1 - k);
                reverse(nums, nums.Length - k, nums.Length - 1);
                reverse(nums, 0, nums.Length - 1);
            }
        }
        public static void reverse(int[] nums, int start, int end)
        {
            int li = start;
            int ri = end;
            int temp;
            while (li < ri)
            {
                temp = nums[li];
                nums[li] = nums[ri];
                nums[ri] = temp;
                li++;
                ri--;
            }
        }
        #endregion

        #region 283. Move Zeroes - Easy
        public static void MoveZeroes(int[] nums,Approach approach)
        {
            switch (approach)
            {
                case Approach.Brute:
                    //TC - O(2N)
                    //SC - O(N)
                    List<int> tempList = new List<int>();

                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (nums[i] != 0)
                        {
                            tempList.Add(nums[i]);
                        }
                    }

                    for (int i = 0; i < tempList.Count; i++)
                    {
                        nums[i] = tempList[i];
                    }
                    for (int i = tempList.Count; i < nums.Length; i++)
                    {
                        nums[i] = 0;
                    }
                    break;

                case Approach.Better:
                   
                    break;

                case Approach.Optimal:
                    int j = -1;
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (nums[i] == 0)
                        {
                            j = i;
                           break;
                        }
                    }
                    if (j > 0)
                    {
                        for (int i = j + 1; i < nums.Length; i++)
                        {
                            if (nums[i] != 0)
                            {
                                int temp = nums[i];
                                nums[i] = nums[j];
                                nums[j] = temp;
                                j++;
                            }
                        }

                    }
                    break;

                default: break;

            }


        }
        #endregion

        #region 26. Missing Number - Easy
        public static int MissingNumber(int[] nums,Approach approach)
        {
            switch (approach)
            {
                case Approach.Brute:
                    for (int i = 1; i <= nums.Length; i++)
                    {
                        bool check = false;
                        for (int j = 0; j < nums.Length; j++)
                        {
                            if (i == nums[i])
                            {
                                check = true;
                                break;
                            }
                        }
                        if (!check)
                        {
                            return i;
                        }
                    }
                    return 0;
                    break;

                case Approach.Better:
                    Dictionary<int,int> dict = new Dictionary<int,int>();
                    for(int i = 1; i <= nums.Length; i++)
                    {
                        dict.Add(i, 0);
                    }
                    for(int i = 0; i < nums.Length; i++)
                    {
                        dict[nums[i]] = 1;
                    }
                    if(!dict.ContainsValue(0)) return 0;
                    return dict.FirstOrDefault(x => x.Value == 0).Key;
                    break;

                case Approach.Optimal:
                    int sum = (nums.Length * (nums.Length + 1)) * 1/2;

                    int actSum = 0;
                    for(int i = 0; i < nums.Length; i++)
                    {
                        actSum += nums[i];
                    }
                     return sum - actSum;
                    break;

                default:  break;
            }
            return 0;


        }
        #endregion

        #region 485. Max Consecutive Ones
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0;
            int temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    temp++;
                }
                if (nums[i] == 0 || i == nums.Length - 1)
                {
                    if (temp > max) max = temp;
                    temp = 0;
                }
            }
            return max;
        }
        #endregion

        #region 136. Single Number - Easy
        public static int SingleNumber(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], 1);
                }
                else
                {
                   
                    dict[nums[i]]=++dict[nums[i]];
                }
            }
            return dict.FirstOrDefault(x=>x.Value==1).Key;
        }
        #endregion

        #region 75. Sort Colors
        public static void SortColors(int[] nums,Approach approach)
        {
            switch (approach)
            {
                case Approach.Brute:
                    //TC - nlogn
                    //SC - N
                    //Merge Sort
                    break;

                case Approach.Better:
                    //TC-2n
                    //SC-1
                    Dictionary<int, int> freq = new Dictionary<int, int>();
                    freq.Add(0, 0);
                    freq.Add(1, 0);
                    freq.Add(2, 0);
                    for (int i = 0; i < nums.Length; i++)
                    {
                        freq[nums[i]]++;
                    }

                    for (int i = 0; i < freq[0]; i++) { nums[i] = 0; }
                    for (int i = freq[0]; i < freq[1] + freq[0]; i++) { nums[i] = 1; }
                    for (int i = freq[1] + freq[0]; i < nums.Length; i++) { nums[i] = 2; }
                    break;

                case Approach.Optimal:
                    //Dutch National flag algorithm
                    //0 to low-1 all 0's
                    //low to mid-1 all 1's
                    //mid to high unsorted
                    //high+1 to n-1 all 2's
                    int low = 0;
                    int mid = 0;
                    int high = nums.Length - 1;

                    while (mid <= high)
                    {
                        if (nums[mid] == 0)
                        {
                            int temp = nums[low];
                            nums[low] = nums[mid];
                            nums[mid] = temp;
                            low++;
                            mid++;
                        }
                        else if (nums[mid] == 1)
                        {
                            mid++;
                        }
                        else if (nums[mid] == 2)
                        {
                            int temp = nums[high];
                            nums[high] = nums[mid];
                            nums[mid] = temp;
                            high--;
                        }
                    }
                    break;

                default: break;

            }
        }
        #endregion

        #region 53. Maximum Subarray
        public static int MaxSubArray(int[] nums,Approach approach)
        {
            switch (approach)
            {
                case Approach.Brute:
                    //TC n3
                    int currentSum = 0;
                    int maxSum = Int32.MinValue;

                    for (int i = 0; i < nums.Length; i++)
                    {
                        for (int j = i; j < nums.Length; j++)
                        {
                            for (int k = i; k <= j; k++)
                            {

                                currentSum += nums[k];

                            }
                            if (currentSum > maxSum) maxSum = currentSum;
                            currentSum = 0;
                        }
                    }
                    return maxSum;
                    break;

                case Approach.Better:
                    int currentSum2 = 0;
                    int maxSum1 = Int32.MinValue;

                    for (int i = 0; i < nums.Length; i++)
                    {
                        currentSum2 = 0;
                        for (int j = i; j < nums.Length; j++)
                        {
                            currentSum2 += nums[j];
                            if (currentSum2 > maxSum1) maxSum1 = currentSum2;
                        }


                    }
                    return maxSum1;
                    break;

                case Approach.Optimal:
                    //TC - N
                    int maxValue = Int32.MinValue;
                    int currentSum1 = 0;

                    for (int i = 0; i < nums.Length; i++)
                    {
                        currentSum1 += nums[i];

                        if (currentSum1 > maxValue)
                        {
                            maxValue = currentSum1;
                        }


                        if (currentSum1 < 0)
                        {
                            currentSum1 = 0;
                        }
                    }
                    return maxValue;
                    break;

                default: break;

            }
            return 0;


        }
        #endregion

        #region 121. Best Time to Buy and Sell Stock
        public static int MaxProfit(int[] prices,Approach approach)
        {
            switch (approach)
            {
                case Approach.Brute:
                    int maxProfit = 0;
                    int currentProfit = 0;


                    for (int i = 0; i < prices.Length; i++)
                    {

                        int buyPrice = prices[i];
                        for (int j = i + 1; j < prices.Length; j++)
                        {
                            //7, 1, 5, 3, 6, 4
                            int sellPrice = prices[j];
                            currentProfit = sellPrice - buyPrice;
                            if (currentProfit > 0 && currentProfit > maxProfit)
                            {
                                maxProfit = currentProfit;
                            }
                        }

                    }
                    if (maxProfit < 0)
                    {
                        return 0;
                    }
                    return maxProfit;
                    break;

                case Approach.Better:
                    break;

                case Approach.Optimal:
                    int mini = prices[0];
                    int mxProfit = 0;

                    for (int i = 0; i < prices.Length; i++)
                    {
                        int cost = prices[i] - mini;

                        maxProfit = Math.Max(mxProfit, cost);
                        mini = Math.Min(mini, prices[i]);
                    }
                    return mxProfit;
                    break;

                default: break;
            }
            return 0;


        }
        #endregion

        #region 2149. Rearrange Array Elements by Sign
        public static int[] RearrangeArray(int[] nums)
        {
            int[] num = new int[nums.Length];
            int p = 0, n = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    num[p] = nums[i];
                    p += 2;
                }
                else
                {
                    num[n] = nums[i];
                    n += 2;
                }
            }
            return num;

        }
        #endregion

        /*//skeleton
          switch(approach)
            {
                case Approach.Brute:
                    break;

                case Approach.Better:
                    break;

                case Approach.Optimal:
                    break;

                default: break;

            } 
         */
    }
}
