using System;
using System.Collections;
using System.Collections.Generic;

namespace LeecodeEasy
{

    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            string s = "abcabcbb";
            Console.WriteLine(S.LengthOfLongestSubstring(s));
        }

    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class Solution
    {
        #region 第一题
        //给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target 的那 两个 整数，并返回它们的数组下标。
        //你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。
        //你可以按任意顺序返回答案。
        public int[] TwoSum(int[] nums, int target)
        {
            //Solution a = new Solution();
            //int[] M = new int[] { 2, 7, 11, 5 };
            //int[] b = new int[] { };
            //b = a.TwoSum(M, 9);
            //foreach (var item in b)
            //{
            //    Console.WriteLine(item);
            //}
            //暴力算法
            //int[] a = new int[2];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] + nums[j] == target)
            //        {
            //            a[0] = i; a[1] = j;
            //        }
            //    }
            //}
            //return a;
            //哈希字典
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int M = target - nums[i];
                if (dic.ContainsKey(M))
                {
                    return new int[] { i, dic[M] };
                }
                else
                {
                    //键为数组值，值为索引
                    dic.Add(nums[i], i);
                }

            }
            return null;
        }
        #endregion

        #region 第二题
        // 给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。
        //请你将两个数相加，并以相同形式返回一个表示和的链表。
        //你可以假设除了数字 0 之外，这两个数都不会以 0 开头

        //int[] a = new int[] { 9, 9, 9, 9, 9, 9, 9 };
        //int[] b = new int[] { 9, 9, 9, 9 };
        //ListNode l1 = S.CreatListNode(a);
        //ListNode l2 = S.CreatListNode(b);
        //ListNode result = S.AddTwoNumbers(l1, l2);
        //S.DispList(result);

        /// <summary>
        /// 创造链表
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public ListNode CreatListNode(int[] a)
        {
            ListNode s = new ListNode();
            ListNode r = s;
            for (int i = 0; i < a.Length; i++)
            {
                ListNode l = new ListNode();
                l.val = a[i];
                r.next = l;
                r = r.next;
            }
            r.next = null;
            return s;
        }
        /// <summary>
        /// 输出链表
        /// </summary>
        /// <param name="l"></param>
        public void DispList(ListNode l)
        {
            ListNode p = l.next;
            while (p != null)
            {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }


        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(-1);
            ListNode cur = result;
            int carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                int x = (l1 == null) ? 0 : l1.val;
                int y = (l2 == null) ? 0 : l2.val;
                int sum = x + y + carry;
                carry = sum / 10;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }
            return result.next;
        }
        #endregion

        #region 第三题
        // 给定一个字符串 s ，请你找出其中不含有重复字符的 最长子串 的长度。
        public int LengthOfLongestSubstring(string s)
        {
            //窗口
            int left = 0;
            int right = 0;
            
            int Len = 0;
            int max = 0;
            List<char> L = new List<char>();
            while (right < s.Length)
            {
                if (!L.Contains(s[right]))
                {
                    L.Add(s[right]);
                    right++;
                    //窗口值
                    Len++;
                }
                else
                {
                    L.Remove(s[right]);
                    left++;
                    Len--;
                }
                max = Math.Max(max, Len);
            }
            return max;
        }
        #endregion
    }
}
