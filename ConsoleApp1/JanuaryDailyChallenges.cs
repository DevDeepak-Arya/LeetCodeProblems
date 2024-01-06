using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    public static class JanuaryDailyChallenges
    {
        public enum Approach
        {
            Brute,
            Better,
            Optimal
        }

        #region 455. Assign Cookies - Easy
        // Explaination https://www.youtube.com/watch?v=2oZD3GfboFo
        public static int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Reverse(g);
            Array.Sort(s);
            Array.Reverse(s);


            int satisfiedChilds = 0;
            int cookiePointer = 0;

            for (int i = 0; i < g.Length; i++)
            {

                if (cookiePointer < s.Length && g[i] <= s[cookiePointer])
                {
                    satisfiedChilds++;
                    cookiePointer++;
                }
            }
            return satisfiedChilds;

        }

        #endregion

        #region 2610. Convert an Array Into a 2D Array With Conditions
        public static IList<IList<int>> FindMatrix(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();

            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!freq.ContainsKey(nums[i]))
                {
                    freq.Add(nums[i], 0);
                }
                freq[nums[i]]++;
                if (result.Count < freq[nums[i]])
                {
                    result.Add(new List<int>());
                }
                result[freq[nums[i]] - 1].Add(nums[i]);

            }
            return result;

        }
        #endregion

        #region 2125. Number of Laser Beams in a Bank
        public static int NumberOfBeams(string[] bank)
        {
            int poc = 0;
            int ans = 0;
            foreach (string s in bank)
            {
                int coc = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '1')
                    {
                        coc++;
                    }
                }
                if (coc > 0)
                {

                    ans += coc * poc;
                    poc = coc;
                }
            }
            return ans;
        }
        #endregion

        #region 2870. Minimum Number of Operations to Make Array Empty
        public static int MinOperations(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            double result = 0;

            foreach (var el in dict)
            {
                if (el.Value == 1)
                {
                    return -1;
                }
                result += Math.Ceiling((double)el.Value / 3);

            }
            return (int)result;
        }
        #endregion

        #region 300. Longest Increasing Subsequence
        static int[,] t = new int[2501, 2501];

        public static int maxOfSubarray(int i, int p, int[] nums)
        {
            if (i >= nums.Length)
            {
                return 0;
            }
            if (p != -1 && JanuaryDailyChallenges.t[i,p] != -1)
            {
                return JanuaryDailyChallenges.t[i,p];
            }
            int take = 0;
            //take
            if (p == -1 || nums[i] > nums[p])
            {
                take = 1 + maxOfSubarray(i + 1, i, nums);
            }
            int skip = 0;
            //skip
            skip = maxOfSubarray(i + 1, p, nums);

            if (p != -1) { JanuaryDailyChallenges.t[i,p] = Math.Max(take, skip); }
            return Math.Max(take, skip);
        }
        public static int LengthOfLIS(int[] nums)
        {
            
            for (int i = 0; i < 2501; i++)
            {
                for (int j = 0; j < 2501; j++)
                {
                    t[i, j] = -1;
                }
            }
            return maxOfSubarray(0, -1, nums);
        }
        #endregion

        #region 1235. Maximum Profit in Job Scheduling
         static int n;
         static int[] memo = new int[50001];
        static int getNextIndex(List<List<int>> array, int l, int currentJobEnd)
        {
            int r = n - 1;
            int result = n + 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (array[mid][0] >= currentJobEnd)
                {
                    result = mid;
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return result;
        }

        static int Solve(List<List<int>> array, int i)
        {
            if (i >= n)
            {
                return 0;
            }
            if (memo[i] != -1) { return memo[i]; }
            int next = getNextIndex(array, i + 1, array[i][1]);
            int taken = array[i][2] + Solve(array, next);

            int notTaken = Solve(array, i + 1);

            return memo[i] = Math.Max(taken, notTaken);

        }

       static public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            n = startTime.Length;
            List<List<int>> arrayProfit = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                arrayProfit.Add(new List<int>() { startTime[i], endTime[i], profit[i] });
            }
            List<List<int>> array = arrayProfit.OrderBy(sublist => sublist[0]).ToList();

            for (int i = 0; i < memo.Length; i++) { memo[i] = -1; }

            return Solve(array, 0);

        }
        #endregion
    }
}
