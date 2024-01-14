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

        #region 446. Arithmetic Slices II - Subsequence
        public static int NumberOfArithmeticSlices(int[] nums)
        {
            int ans = 0;

            Dictionary<int, int>[] maps = new Dictionary<int, int>[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                maps[i] = new Dictionary<int, int>();
            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    long cd = (long)nums[i] - (long)nums[j];
                    if (cd <= Int32.MinValue || cd >= Int32.MaxValue)
                    {
                        continue;
                    }

                    int apsEndingOnJ = maps[j].GetValueOrDefault((int)cd);
                    int apsEndingOnI = maps[i].GetValueOrDefault((int)cd);

                    ans += apsEndingOnJ;
                    if (maps[i].TryGetValue((int)cd, out int apsEndingOni))
                    {
                        maps[i][(int)cd] = apsEndingOnJ + apsEndingOni + 1;
                    }
                    else
                    {
                        maps[i].Add((int)cd, apsEndingOnJ + apsEndingOnI + 1);
                    }
                }
            }

            return ans;

        }
        #endregion

        #region 1704. Determine if String Halves Are Alike
        public static bool HalvesAreAlike(string s)
        {
            string a = s.Substring(0, s.Length / 2);
            string b = s.Substring(s.Length / 2 );

            int count1 = VowelCount(a);
            int count2 = VowelCount(b);

            if (count1 == count2) { return true; }
            return false;


        }

        static int VowelCount(string input)
        {
            int sum = 0;
            foreach (char c in input)
            {
                if (IsVowel(c))
                {
                    sum++; // If a vowel is found, increment the value
                }
            }
            return sum;
        }
        static bool IsVowel(char character)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return Array.IndexOf(vowels, character) != -1;
        }
        #endregion

        #region 1347. Minimum Number of Steps to Make Two Strings Anagram
        public static int MinSteps(string s, string t)
        {
            Dictionary<char, int> dic1 = new Dictionary<char, int>();
            Dictionary<char, int> dic2 = new Dictionary<char, int>();
            int flipCount = 0;
            int extraCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (dic1.ContainsKey(s[i]))
                {
                    dic1[s[i]]++;
                }
                else
                {
                    dic1.Add(s[i], 1);
                }
                if (dic2.ContainsKey(t[i]))
                {
                    dic2[t[i]]++;
                }
                else
                {
                    dic2.Add(t[i], 1);
                }
            }

            foreach (var val in dic1)
            {
                if (dic2.ContainsKey(val.Key))
                {
                    if (dic2[val.Key] == dic1[val.Key]) continue;
                    else
                    {
                        if (dic1[val.Key] - dic2[val.Key] < 0)
                        {
                            extraCount = extraCount + (dic2[val.Key] - dic1[val.Key]);
                        }
                        else
                        {
                            flipCount = flipCount + (dic1[val.Key] - dic2[val.Key]);
                        }
                    }
                }
                else
                {
                    flipCount = flipCount + dic1[val.Key];
                }

            }
            if (Math.Abs(flipCount - extraCount) == 0)
            {
                return flipCount;
            }

            return Math.Abs(flipCount - extraCount);


        }
        #endregion

        #region 1657. Determine if Two Strings Are Close
        public static bool CloseStrings(string word1, string word2)
        {
            int word1Length = word1.Length;
            int word2Length = word2.Length;
            if (word1Length != word2Length) { return false; }


            int[] word1FrequencyArray = new int[26];
            int[] word2FrequencyArray = new int[26];

            // Iterate through each character in the string
            for (int i = 0; i < word1.Length; i++)
            {
                // Check if the character is an English alphabet letter
                if (word1[i] >= 'a' && word1[i] <= 'z')
                {
                    // Increment the frequency of the corresponding character in the array
                    word1FrequencyArray[word1[i] - 'a']++;
                }

                if (word2[i] >= 'a' && word2[i] <= 'z')
                {
                    // Increment the frequency of the corresponding character in the array
                    word2FrequencyArray[word2[i] - 'a']++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (word1FrequencyArray[i] != 0 && word2FrequencyArray[i] != 0) continue;
                if (word1FrequencyArray[i] == 0 && word2FrequencyArray[i] == 0) continue;
                return false;
            }
            Array.Sort(word1FrequencyArray);
            Array.Sort(word2FrequencyArray);
            if (word1FrequencyArray.SequenceEqual(word2FrequencyArray)) return true;
            return false;

        }
        #endregion
    }
}
