using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    public class RefList<T>
    {

        private T[] data; // backing store 
        public ref T this[int index] => ref data[index];
        // ... other methods
    }
}
