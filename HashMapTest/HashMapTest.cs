using HashMap;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashMapTest
{
    public class HashMapTest
    {
        [Theory]
        [InlineData(1, "Stan")]
        [InlineData(2, "Michael")]
        [InlineData(3, "Karan")]
        public void TestForContainsKeyWorks(int key, string value)
        {
            KeyValuePair<int, string> test = new KeyValuePair<int, string>(key, value);

            var hashmapuu = new HashMap<int, string>();

            hashmapuu.Add(test);

            //bool expected = true;

            bool result = hashmapuu.Contains(test);

            Assert.True(result);

        }

        [Theory]
        [InlineData(1, "stan")]
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

        [Theory]
        [InlineData(1, "stan")]
        [InlineData(2, "Michael")]
        [InlineData(3, "Karan")]
        public void TestForRemove(int key, string value)
        {
            var testKVP = new KeyValuePair<int, string>(key, value);

            var hashmap = new HashMap<int, string>();

            hashmap.Add(testKVP);

            hashmap.Remove(testKVP.Key);

            Assert.False(hashmap.Contains(testKVP));


        }
        [Fact]
        public void TestForClear()
        {
            var testKVP = new KeyValuePair<int, string>(1, "stan");

            var hashmap = new HashMap<int, string>();

            hashmap.Add(testKVP);

            hashmap.Clear();

            Assert.True(hashmap.Count == 0);

            //Assert.True(hashmap.Capacity == 0); //Array.Clear() maintains the size of the original array

        }


        [Fact]
        public void TestForIndex()
        {
            var hashmap = new HashMap<int, string>();
            hashmap.Add(new KeyValuePair<int, string> (4, "stan"));

            try
            {
                hashmap[4] = "aoksoaksd";
                Assert.True(false);
            }
            catch(KeyNotFoundException ex)
            {
                Assert.True(true);
            }

            //Assert.Throws(typeof(KeyNotFoundException), () =>
            //{
            //    hashmap[2] = "soamkd";
            //});
        }


    }
}
