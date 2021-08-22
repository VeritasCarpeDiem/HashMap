using System;
using System.Collections.Generic;
using Xunit;

namespace HashMapTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new KeyValuePair<TKey,TValue>(1, "stan")]
        public void TestThatContainsWorks(KeyValuePair<TKey, TValue> item)
        {

        }

        [Theory]
        [InlineData (1, "stan")]
        public void TestForAdd(int key, string value)
        {

        }
    }
}
