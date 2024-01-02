using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    public static class Strings
    {
        public enum Approach
        {
            Brute,
            Better,
            Optimal
        }

        #region ParanthesisChecker
        public static bool ParanthesisChecker(string s)
        {
            //Your code here
            char[] chars = s.ToCharArray();

            if (chars.Length % 2 != 0)
            {
                return false;
            }

            char c;

            Stack<char> myStack = new Stack<char>();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '{' || chars[i] == '[' || chars[i] == '(')
                {
                    myStack.Push(chars[i]);

                }
                if (chars[i] == '}')
                {
                    //edge case
                    if (myStack.Count == 0) { return false; }
                    c = myStack.Peek();
                    if (c == '{') { myStack.Pop(); } else { return false; }
                }
                if (chars[i] == ']')
                {
                    if (myStack.Count == 0) { return false; }
                    c = myStack.Peek();
                    if (c != '[') { myStack.Pop(); } else { return false; }
                }
                if (chars[i] == ')')
                {
                    if (myStack.Count == 0) { return false; }
                    c = myStack.Peek();
                    if (c != '(') { myStack.Pop(); } else { return false; }
                }

            }
            if (myStack.Count == 0) { return true; }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReverseWordInAGivenString
        public static string reverseWords(string s)
        {

            //Your code here
           string[] str = s.Split('.');

           Array.Reverse(str);
           string result=  string.Join(".", str);
            return result;
        }
        #endregion

        #region Anagram
        public static bool isAnagram(string a, string b)
        {
            char[] a1=a.ToCharArray();
            char[] b1=b.ToCharArray ();
            // Your code here
            Array.Sort(a1);
            Array.Sort(b1);

            string str =new string(a1);
            string str1 = new string(b1);
            
            if (string.Equals(str,str1)) { return true; } else { return false; }

        }

        #endregion

        #region PalindromeString
        public static int isPalindrome(String S)
        {
            // code here
            char[] c= S.ToCharArray();
            Array.Reverse (c);
            string s1= new string(c);

            if(S == s1) { return 1; }else { return 0; }
        }
        #endregion

        #region LongestCommonPrefix
        //public String LongestCommonPrefix(string[] arr, int n)
        //{
        //  // code here


        //}

        #endregion

        #region 13 RomanToInt - Easy
        #region ProblemStatement
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

 

            Example 1:

            Input: s = "III"
            Output: 3
            Explanation: III = 3.
            Example 2:

            Input: s = "LVIII"
            Output: 58
            Explanation: L = 50, V= 5, III = 3.
            Example 3:

            Input: s = "MCMXCIV"
            Output: 1994
            Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 

            Constraints:

            1 <= s.length <= 15
            s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
            It is guaranteed that s is a valid roman numeral in the range [1, 3999].*/
        #endregion

        public static int RomanToInt(string s,Approach approach)
        {
            int total = 0;
            switch (approach)
            {
                case Approach.Brute:
                    
                    IDictionary<char, int> romanValues = new Dictionary<char, int>()
                    {
                        {'I',1},
                        {'V',5},
                        {'X',10},
                        {'L',50},
                        {'C',100},
                        {'D',500},
                        {'M',1000}
                    };
                    
                    char[] chars = s.ToCharArray();
                    for(int i = 0; i < s.Length-1; i++)
                    {
                        total=(romanValues[chars[i]] < romanValues[chars[i + 1]] ? total -= romanValues[chars[i]] : total += romanValues[chars[i]]);
                    };
                    total = total + romanValues[chars[chars.Length - 1]];
                    break;

                case Approach.Better:

                    IDictionary<char, int> newRomanValues = new Dictionary<char, int>()
                    {
                        {'I',1},
                        {'V',5},
                        {'X',10},
                        {'L',50},
                        {'C',100},
                        {'D',500},
                        {'M',1000}
                    };
                    s=s.Replace("IV", "IIII");
                    s=s.Replace("IX", "VIIII");
                    s=s.Replace("XL", "XXXX");
                    s=s.Replace("XC", "LXXXX");
                    s=s.Replace("CD", "CCCC");
                    s=s.Replace("CM", "DCCCC");
                    char[] newChars = s.ToCharArray();
                    for (int i = 0;i<s.Length;i++)
                    {
                        total += newRomanValues[newChars[i]];
                    }
                    break;

                case Approach.Optimal:
                    break;

                default: break;
                    
            }
            return total;

        }
        #endregion

        #region 14 Longest Common Prefix - Easy
        public static string LongestCommonPrefix(string[] strs,Approach approach)
        {
            string result = "";
            switch (approach)
            {
                case Approach.Brute:
                    string checkStr = strs[0];

                    for (int i = 0; i < checkStr.Length; i++)
                    {
                        for (int j = 1; j < strs.Length; j++)
                        {
                            if (i>=strs[j].Length||checkStr[i] != strs[j][i])
                            {
                                return result;
                            }

                            
                        }
                        result += checkStr[i];
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

        #region 28. Find the Index of the First Occurrence in a String - Easy
        public static int StrStr(string haystack, string needle)
        {
            int result = haystack.IndexOf(needle);
            return result;
        }
        #endregion

        #region 58. Length of Last Word - Easy
        public static int LengthOfLastWord(string s)
        {
            s=s.Trim();
            string[] words = s.Split(' ');
            int result = words[words.Length - 1].Length;
            return result;
        }
        #endregion

        #region 1021. Remove Outermost Parentheses
        public static string RemoveOuterParentheses(string s)
        {
            s = s.Trim();
            string[] temp = s.Split(' ');
            for (int i = 0; i < temp.Length; i++) temp[i] = temp[i].Trim();
            Array.Reverse(temp);
            string result = String.Join(' ', temp);
            return result;
        }
        #endregion

        #region 151. Reverse Words in a String
        public static string ReverseWords(string s)
        {
            s = s.Trim();
            string[] temp = s.Split(' ');
            for (int i = 0; i < temp.Length; i++) 
            {
                temp[i] = temp[i].Trim();
            }
            temp = temp.Where(val => val != "").ToArray();
            Array.Reverse(temp);
            string result = String.Join(' ', temp);
            return result;
        }
        #endregion

        #region 1903. Largest Odd Number in String
        //public static string LargestOddNumber(string num)
        //{
           

        //}
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
