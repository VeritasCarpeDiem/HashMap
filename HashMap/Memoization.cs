using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    public class Memoization
    {

        public static Dictionary<int, long> memo = new Dictionary<int, long>();

        public long FibMemo(int n)
        {
            if (memo.ContainsKey(n)) return memo[n];

            if (n <= 2) return 1;

            memo[n] = FibMemo(n - 1) + FibMemo(n - 2);

            return memo[n];

            
        }

        
    }
}
