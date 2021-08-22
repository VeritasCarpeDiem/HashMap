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


        /// <summary>
        /// Represents count of key value pairs
        /// </summary>
        public int Count { get; private set; }

        public int Capacity => collection.Length;

        public const int bucketSize = 10;

        #endregion

        #region Methods
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
                var linkedlist = collection[index];
                linkedlist = new LinkedList<KeyValuePair<TKey, TValue>>();

                linkedlist.AddLast(new KeyValuePair<TKey, TValue>(key, value));

                Count++;
               
            }
            if(Count == Capacity)
            {
                Rehash();
            }
            if(ContainsKey(key))
            {
                throw new ArgumentException("Duplicate Key exists!");
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(new KeyValuePair<TKey,TValue>(item.Key, item.Value));
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
            if(Count>0)
            {
                Array.Clear(collection, 0, Capacity);
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int index = TKeyToIndex(item.Key);

            foreach (var kvp in collection[index])
            {
                if (collection[index].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            GetKeyValuePair(key);
            TryGetValue(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            //var newCollection = new LinkedList<KeyValuePair<TKey, TValue>>();
            //Array.Copy(collection, newCollection, Capacity);

            foreach (var kvp in collection)
            {
                array[arrayIndex] = kvp; //???
                arrayIndex++;
            }
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

        bool ICollection<KeyValuePair<TKey,TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if(Contains(item))
            {
                Remove(item.Key);

                return true;
            }

            return false;
        }
        /// <summary>
        /// https://stackoverflow.com/questions/2432909/what-does-defaultobject-do-in-c#:~:text=The%20default%20keyword%20returns%20the,00%3A00%20%2C%20etc).
        /// </summary>
        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var pair = GetKeyValuePair(key);
            if(pair.HasValue)
            {
                value = pair.Value.Value;
                return true;
            }
            value = default(TValue);

            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var ll in collection)
            {
                foreach (var kvp in ll)
                {
                    yield return kvp;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }

}
