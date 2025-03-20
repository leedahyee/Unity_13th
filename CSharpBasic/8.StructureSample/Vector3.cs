using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _8.StructureSample {
    // 구조체의 장점은, 값타입으로 빠르게 데이터 그룹을 읽고 쓰는 것인데
    // 구조체는 16byte를 넘어가게 되면 참조타입을 전달하는 것 보다 성능이 좋지 않다
    struct Vector3 {
        // 접근 제한자
        // public       - 외부에서 접근 가능
        // internal     - 동일 어셈블리 (코드조각, ece / dll 등 같으 프로그램 단위) 에서 접근 가능
        // protected    - 상속자만 접근 가능
        // private      - 외부 접근 불가능

        // 구조체는 기본적으로 내부 데이터를 보호하는 컨셉이기 때문에 접근 제한자를 명시하지 않으면 private임
        public Vector3(float x, float y, float z) {
            _x = x;
            _y = y;
            _z = z;
        } // 생성자
        
        /*
         * 람다식 표현
         * 컴파일러가 판단할 수 있는 요소를 생략하는 표현방식
         * 생략할거 다 생략한 다음 '파라미터 -> 구현부' 형식으로 작성함
         */
        public static Vector3 Forward => new Vector3(0f, 0f, 1f);

        public static Vector3 Back => new Vector3(0f,0f,-1f);
        public static Vector3 Right => new Vector3(1f,0f,0f);
        public static Vector3 Left => new Vector3(-1f,0f,0f);
        public static Vector3 Up => new Vector3(0f,1f,0f);
        public static Vector3 Down => new Vector3(0f,-1f,0f);

        public static Vector3 Zero => new Vector3(0f,0f,0f);
        public static Vector3 One => new Vector3(1f,1f,1f);
        public float Magnitude => (float)Math.Sqrt(_x * _x + _y * _y + _z * _z); // Math.Sqrt() double 형

        public Vector3 Noremalized => new Vector3(_x / Magnitude, -Y/ Magnitude, -Z/ Magnitude);


        float _x, _y, _z;  


        // 프로퍼티 : getter와 setter를 간편하게 구현할 수 있는 기능 (캡슐화 용도)
        //            get 접근사와 set 접근사를 선택적으로 정의하여 멤버의 직접 접근을 보호할 수 있다
        //            get 혹은 set에 선택적으로 접근제한자를 추가할 수 있다
        //public float Id { get; private set; }
        //// 위 아래 같은 것임
        //public float id {
        //    get {
        //        return _id;
        //    };
        //    set {
        //        _id = value;
        //    }
        //}

        //float _id;

        public float X {
            get { return _x; }
            set { _x = value; }
        }

        public float Y {
            get { return _y; }
            set { _y = value; }
        }

        public float Z {
            get { return _z; }
            set { _z = value; }
        }

        // 캡슐화 : getter와 setter를 만드는 것
        //          고유 데이터 (멤버 변수) 를 외부로부터 보호하는 컨셉을 적용하는 과정
        public float getX ()  { 
            return _x; 
        }

        public void setX(float x) {
            _x = x;
        }

        public float getY() {
            return _y;
        }
        public void setY(float y) {
            _y = y;
        }
        public float getZ() {
            return _z;
        }
        public void setZ(float z) {
            _z = z;
        }

        public void MoveX(float distance) {
            _x = distance;
        }

        public static float Distance(Vector3 op1, Vector3 op2)
        => (float)Math.Sqrt((op1._x - op2._x) * (op1._x - op2._x) +
                              (op1._y - op2._y) * (op1._y - op2._y) +
                                (op1._z - op2._z) * (op1._z - op2._z));
            
        // 연산자 오버로딩
        public static Vector3 operator /(Vector3 op1, float op2)
            => new Vector3(op1._x / op2, op1._y / op2, op1._z / op2);

        public static Vector3 operator /(Vector3 op1, int op2)
            => new Vector3(op1._x / op2, op1._y / op2, op1._z / op2);

        public static Vector3 operator *(Vector3 op1, float op2)
            => new Vector3(op1._x / op2, op1._y / op2, op1._z / op2);
        public static Vector3 operator *(Vector3 op1, int op2)
            => new Vector3(op1._x / op2, op1._y / op2, op1._z / op2);
        public static bool operator ==(Vector3 op1, Vector3 op2)
                    => (op1._x == op2._x) && (op1._y == op2._y) && (op1._z == op2._z);
        public static bool operator !=(Vector3 op1, Vector3 op2)
            => !(op1 == op2);
    }
}
