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
        public void TestForContainsKeyWorks(int key, string value)
        {
            KeyValuePair<int, string> test= new KeyValuePair<int, string>(key, value);

            var hashmapuu = new HashMap<int, string>();

            hashmapuu.Add(test);

            //bool expected = true;
            
            bool result = hashmapuu.Contains(test);

            Assert.True(result);
            
        }

        [Theory]
        [InlineData (1, "stan")]
        [InlineData(2, "Michael")]
        [InlineData(3, "Karan")]
        public void TestForAdd(int key, string value)
        {
            KeyValuePair<int, string> test = new KeyValuePair<int, string>(key, value);

            var hashmapuu = new HashMap<int, string>();

            hashmapuu.Add(test);

            Assert.True(hashmapuu.Values.Contains(value));
            Assert.True(hashmapuu.Keys.Contains(key));
        }
    }
}
