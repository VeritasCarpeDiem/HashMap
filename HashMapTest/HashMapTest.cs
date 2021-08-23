using HashMap;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashMapTest
{
    public class HashMapTest
    {
        [Theory]
        [InlineData (1, "Stan")]
        [InlineData(2, "Michael")]
        [InlineData(3, "Karan")]
        public void TestThatContainsKeyWorks(int key, string value)
        {
            KeyValuePair<int, string> test= new KeyValuePair<int, string>(key, value);

            var hashmapuu = new HashMap<int, string>(10);

            bool expected = true;
            
            bool result = hashmapuu.Contains(test);

            Console.WriteLine(expected == result);
            
        }

        [Theory]
        [InlineData (1, "stan")]
        public void TestForAdd(int key, string value)
        {
            
        }
    }
}
