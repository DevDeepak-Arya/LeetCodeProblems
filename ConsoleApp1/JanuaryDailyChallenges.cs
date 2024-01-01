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
    }
}
