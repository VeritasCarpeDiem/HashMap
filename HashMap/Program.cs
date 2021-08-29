using System;
using System.Collections.Generic;

namespace HashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            #region Hashmap
            HashMap<int, string> hashmap = new HashMap<int, string>();
            string output = "hi";

            List<int> other = new List<int>();
            List<int> l = new List<int>(other);

            bool hasValue = hashmap.TryGetValue(5, out output);
            Console.Write(output);

            foreach (var item in hashmap)
            {
                ;
            }
            #endregion 
            */

            //Memoization memo = new Memoization();
            //Console.WriteLine(memo.FibMemo(6));

            HashMap<int, string> hashmap = new HashMap<int, string>(10);

            KeyValuePair<int, string> item = new KeyValuePair<int, string>(1, "stan");
            hashmap.Add(item);


            Console.WriteLine(hashmap.Contains(item));

          
            
        }

    }
}
