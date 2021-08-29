using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace HashMap
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue> //, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable 
    {

        #region Fields
        private LinkedList<KeyValuePair<TKey, TValue>>[] collection;
        private const int defaultCapacity = 10; 
        #endregion

        #region Properties
        /// <summary>
        /// Represents count of key value pairs
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Length of array
        /// </summary>
        public int Capacity => collection.Length;


        public ICollection<TKey> Keys => this.Select(x => x.Key).ToList();

        public ICollection<TValue> Values => this.Select(x => x.Value).ToList();

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

        #endregion

        #region Methods

        public HashMap(int defaultCapacity = defaultCapacity)
        {
            this.collection = new LinkedList<KeyValuePair<TKey, TValue>>[defaultCapacity];

        }

        public TValue this[TKey key]
        {
            set
            {
                var pair = GetKeyValuePair(key);

                if (pair.HasValue)
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

            if(linkedlist is null)
            {
                return null;
            }
            
            foreach (var node in linkedlist)
            {
                if (node.Key.Equals(key))
                {
                    return node;
                }
            }
            return null;
        }

        private int TKeyToIndex(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % Capacity);

            return index;
        }
       

        public void Add(TKey key, TValue value)
        {
            int index = TKeyToIndex(key);

            //var ll = collection[index];
            
            if (Count == Capacity)
            {
                Rehash(Capacity * 2);
            }
            if (ContainsKey(key))
            {
                throw new ArgumentException("Duplicate Key exists!");
            }
            if (collection[index] == null)
            {
                
               collection[index] = new LinkedList<KeyValuePair<TKey, TValue>>();

            }
            collection[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));

            Count++;
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Add(KeyValuePair<TKey,TValue> item)
        {
           ((IDictionary<TKey,TValue>)this).Add(item);
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
            if (Count > 0)
            {
                Array.Clear(collection, 0, Capacity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Rehash(int capacity)
        {
            var tempCollection = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];

            foreach (var ll in collection)
            {
                if (ll is null) continue;

                foreach (var kvp in ll)
                {
                    int index = TKeyToIndex(kvp.Key);

                    if (tempCollection[index] == null)
                    {
                        tempCollection[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                    }
                    tempCollection[index].AddLast(kvp);
                    //add to it
                    //Grab index of kvp
                    //insert into new collection

                }
            }

            //set our original collection to tempcollection
            collection = tempCollection;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            //int index = TKeyToIndex(item.Key);
            var kvp = GetKeyValuePair(item.Key);

            if(kvp.HasValue && kvp.Value.Value.Equals(item.Value))
            {
                return true;
            }
            //foreach (KeyValuePair<TKey,TValue> kvp in collection[index])
            //{
            //    if (collection[index].Equals(item))
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            var pair = GetKeyValuePair(key);
            return pair.HasValue;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new Exception("");

            //var newCollection = new LinkedList<KeyValuePair<TKey, TValue>>();
            //Array.Copy(collection, newCollection, Capacity);

            //foreach (LinkedList<KeyValuePair<TKey, TValue>> kvp in collection)
            //{
            //    array[arrayIndex] = kvp; //???
            //    arrayIndex++;
            //}

            //foreach (KeyValuePair<TKey, TValue> kvp in this)
            //{
            //    array[arrayIndex] = kvp; //???
            //    arrayIndex++;
            //}
        }

        public bool Remove(TKey key)
        {
            int index = key.GetHashCode();

            var list = collection[index];
            foreach (var node in list)
            {
                if (node.Key.Equals(key))
                {
                    list.Remove(node);

                    return true;
                }
            }

            return false;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if (Contains(item))
            {
                Remove(item.Key);

                return true;
            }

            return false;
        }
        /// <summary>
        /// https://stackoverflow.com/questions/2432909/what-does-defaultobject-do-in-c#:~:text=The%20default%20keyword%20returns%20the,00%3A00%20%2C%20etc).
        /// </summary>
        bool IDictionary<TKey, TValue>.TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var pair = GetKeyValuePair(key);
            if (pair.HasValue)
            {
                value = pair.Value.Value;
                return true;
            }
            value = default(TValue);

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return ((IDictionary<TKey, TValue>)this).TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            foreach (var ll in collection)
            {
                if(ll is null)
                {
                    continue;
                }

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
