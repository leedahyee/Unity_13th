namespace CollectionSample {
    class DynamicArray<T> {
        public DynamicArray(int capacity) {
            _data = new T[capacity];
        }

        private T[] _data;
        private int _count;

        public int Count => _count;

        public T this[int index] {
            get {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();
                return _data[index];
            }
            set {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();
                _data[index] = value;
            }
        }


        public int Capacity {
            get => _data.Length;

            set {
                if (_count > value)
                    throw new ArgumentException("현재 아이템 수 보다 작은 용량으로 설정할 수 없습니다");

                T[] temp = new T[value];

                for (int i = 0; i < _count; i++)
                    temp[i] = _data[i];

                _data = temp;
            }
        }


        public void Add(T item) {
            if (_count == _data.Length) {
                T[] temp = new T[_count * 2];

                for (int i = 0; i < _count; i++) {
                    temp[i] = _data[i];
                }

                _data = temp;
            }

            _data[_count++] = item;
        }


        public void RemoveAt(int index) {
            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            for (int i = index; i < _count - 1; i++)
                _data[i] = _data[i + 1];

            _count--;
        }


        public int FindLastIndex(Predicate<T> match) {
            for (int i = _count - 1; i >= 0; i--) {
                if (match(_data[i])) {
                    return i;
                }
            }
            return -1;
        }


        public bool Remove(Predicate<T> match) {
            int index = FindLastIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }
    }
}