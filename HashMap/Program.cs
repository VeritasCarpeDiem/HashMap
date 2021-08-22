using System;
using System.Collections.Generic;

namespace HashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            HashMap<int, string> hashmap = new HashMap<int, string>();
            string output = "hi";

            bool hasValue = hashmap.TryGetValue(5, out output);
            Console.Write(output);

            foreach (var item in hashmap)
            {
                ;
            }
        }
    }
}
