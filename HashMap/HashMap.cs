using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HashMap
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue> //, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable 
    {

        #region Fields
        private LinkedList<KeyValuePair<TKey, TValue>>[] collection;
        //public int Count => collection.Length;

        public const int bucketSize = 10;

        private IComparer comparer;

        #endregion
        public TValue this[TKey key]
        {
            set
            {
                var pair = GetKeyValuePair(key);

                if(pair.HasValue)
                {
                    Remove(key);
                }

                Add(key, pair.Value.Value);

                throw new Exception("Key not found!");
            }
            get
            {
                var pair = GetKeyValuePair(key);

                if (pair.HasValue)
                {
                    return pair.Value.Value;
                }

                throw new KeyNotFoundException();
            }
        }

        private KeyValuePair<TKey, TValue>? GetKeyValuePair(TKey key)
        {
            //From key to number

            //Array[index]
            var linkedlist = collection[TKeyToIndex(key)];


            foreach (var node in linkedlist)
            {
                if (node.Key.Equals(key))
                {
                    return node;
                }
            }
            return null;
        }

        public int TKeyToIndex(TKey key)
        {
            int index = key.GetHashCode() % collection.Length;

            return index;
        }
        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();


        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            int index = TKeyToIndex(key);
            
            if(collection[index] == null)
            {
                

                collection[index] = new KeyValuePair<TKey,TValue>(key);
            }
            
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Resize(int newBucketSize)
        {
            var newCollection = new LinkedList<KeyValuePair<TKey, TValue>>[newBucketSize];

            for (int i = 0; i < newCollection.Length; i++)
            {
                newCollection[i] = collection[i];
            }

            collection = newCollection;
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            int index = key.GetHashCode();

            var list = collection[index];
            foreach (var node in list)
            {
                if(node.Key.Equals(key))
                {
                    list.Remove(node);

                    return true;
                }
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
