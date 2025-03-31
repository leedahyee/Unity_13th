using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionSample
{
    class DynamicArray<T>
    {
        public T[] _data;
        private int _count;

        public DynamicArray(int capacity) {
            _data = new T[capacity];
        }

        public int Capcity => _count;
    }
}
