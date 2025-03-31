using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionSample
{
    class DynamicArray
    {
        public DynamicArray(int capacity) {
            _data = new object[capacity];


        }

        // 반환 타입이 object가 되어야하므로 this 왼쪽에 있는 자료형이 object로 변환되어야함
        public object this[int index] {
            get {
                if (index >= _count || index <0)
                    throw new IndexOutOfRangeException();
                return _data[index];
            }

            set {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();
                _data[index] = value;
            }
        }

        public int Count => _count; // 읽기 전용

        public int Capacity {
            get => _data.Length;
            set {
                if (_count > value)
                    throw new ArgumentException("현재 아이템 수 보다 작은 용량으로 설정할 수 없습니다.");

                object[] temp = new object[value];

                for(int i=0; i<_count; i++) {
                    temp[i] = _data[i];
                }

                _data = temp;
            }
        }

        private object[] _data;
        private int _count;

        // object타입의 배열을 쓰기 때문에 object item이 들어가야함
        public void Add(object item) { 
            if(_count == _data.Length) {
                object[] temp = new object[_count * 2]; // 크기 2배

                // 기존 데이터 복사
                for(int i= 0; i < _count; i++) {
                    temp[i] = _data[i]; 
                }

                _data = temp;
            }
            
            _data[_count++] = item;
        }


        /// <summary>
        /// index의 아이템 삭제를 위해 이후 아이템들을 모두 한 칸식 앞으로 당김
        /// </summary>
        /// <param name="index"> 삭제하려는 아이템 위치 </param>
        /// <exception cref="IndexOutOfRangeException"> 인덱스 범위 초과 </exception>
        public void RemoveAt(int index) { 
            if(index >= _count || index < 0)
                throw new IndexOutOfRangeException();
            
            for (int i = index; i < _count - 1; i++) {
                _data[i] = _data[i + 1];
            }

            _count--;
        }


        
        public int FindLastIndex(Predicate<object> match) {
            for (int i = _count -1 ; i >= 0; i--) {
                if (match(_data[i])) {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(Predicate<object> match) {
            int index = FindLastIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }
    }
}
