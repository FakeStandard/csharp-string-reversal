using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace String_reversal_for_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // six nines
            var str = RandomString(100000);

            TestTime(() => ReverseCase1(str), "暴力破解");
            TestTime(() => ReverseCase2(str), "LINQ 反轉方法");
            TestTime(() => ReverseCase3(str), "頭尾對調位置");
            TestTime(() => ReverseCase4(str), "C# Array 原生反轉方法");
        }

        /// <summary>
        /// 暴力破解 O(n)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseCase1(string s)
        {
            string res = string.Empty;

            for (int i = s.Length - 1; i >= 0; i--)
                res += s[i];

            return res;
        }

        /// <summary>
        /// LINQ Reverse method
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseCase2(string s)
        {
            return string.Join("", s.Reverse());
        }

        /// <summary>
        /// 頭尾對調位置 O(n/2)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseCase3(string s)
        {
            char[] c = s.ToCharArray();

            int i = 0;
            int j = s.Length - 1;

            // you can also use a for loop to iterate
            while (i < j)
            {
                // swap
                char temp = c[i];
                c[i] = c[j];
                c[j] = temp;

                i++;
                j--;
            }

            return new string(c);
        }

        /// <summary>
        /// C# Array 原生反轉方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseCase4(string s)
        {
            char[] c = s.ToCharArray();

            Array.Reverse(c);

            return new string(c);
        }

        /// <summary>
        /// 取得亂數產生的字串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random(Guid.NewGuid().GetHashCode());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
                sb.Append(str[random.Next(0, str.Length)]);

            return sb.ToString();
        }

        /// <summary>
        /// 測試 Action 執行時間
        /// </summary>
        /// <param name="action"></param>
        /// <param name="methodName"></param>
        static void TestTime(Action action, string methodName)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            action();
            sw.Stop();

            Console.WriteLine($"Duration: {sw.ElapsedMilliseconds:N0}ms, TestName:{methodName}");
        }
    }
}
