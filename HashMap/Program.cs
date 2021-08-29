using System;
using System.Collections.Generic;

namespace HashMap
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Hashmap
            Comparer<int> comparer = Comparer<int>.Create((x, y) => x.CompareTo(y));


            HashMap<int, string> hashmap = new HashMap<int, string>(Comparer<int>.Default, 10);
            //string output = "hi";

            //List<int> other = new List<int>();
            //List<int> l = new List<int>(other);

            //bool hasValue = hashmap.TryGetValue(5, out output);
            //Console.Write(output);


            hashmap.Add(1, "stan");

            hashmap.Clear();
            ;
            #endregion 
            

            //Memoization memo = new Memoization();
            //Console.WriteLine(memo.FibMemo(6));

           

          
            
        }

    }
}
