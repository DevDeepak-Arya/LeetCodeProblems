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
    }
}
