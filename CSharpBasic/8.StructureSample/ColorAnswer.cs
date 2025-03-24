using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorAnswer
{
    struct ColorAnswer {

        // 생성자 : 외부에서 0에서 1 범위 말고 다른 숫자를 넣을 수도 있음
        public ColorAnswer(float r, float g,float b,float a) {
            _r = Clamp(r);
            _g = Clamp(g);
            _b = Clamp(b);
            _a = Clamp(a);
        }

        public ColorAnswer(float r, float g, float b, float a, bool use255Scale) {
            _use255Scale = use255Scale;
            float max = use255Scale ? 255f : 1f;
            _r = Clamp(r,0f,max);
            _g = Clamp(g, 0f, max);
            _b = Clamp(b, 0f,max);
            _a = Clamp(a, 0f, max );
        }

        public bool Use255Scale {
            get => _use255Scale;
            set => _use255Scale = value;
        }

        public float R {
            get=>_r;
            set { _r = Clamp(value, 0f, 1f); } 
        }

        public float G {
            get => _g;
            set { _g = Clamp(value, 0f, 1f); }
        }

        public float B {
            get => _b;
            set { _b = Clamp(value, 0f, 1f); }
        }

        public float A {
            get => _a;
            set { _a = Clamp(value, 0f, 1f); }
        }

        public static ColorAnswer White => new ColorAnswer() {R= 1.0f, G = 1.0f, B = 1.0f, A = 1.0f, };
        public static ColorAnswer Black => new ColorAnswer() { R = 0.0f, G = 0.0f, B = 0.0f, A = 1.0f, };
        public static ColorAnswer Red => new (1.0f, 0.0f, 0.0f, 1.0f);


        float _r, _g, _b, _a; // 이 예제에서는 멤버 변수가 캡슐화 되어있지만, 구조체는 값을 빠르게 읽고 쓰는 이점 때문에 사용하므로
        // 멤버변수를 public으로 공개해서 캡슐화하지 않고 사용하는 경우가 많다
        bool _use255Scale;
        
        /// <summary>
        /// 값 범위 제한
        /// </summary>
        /// <param name="value"> 원본 값 </param>
        /// <param name="min"> 범위 최소 값 </param>
        /// <param name="max"> 범위 최대 값 </param>
        /// <returns> 제한된 값 </returns>
        private float Clamp(float value, float min = 0f, float max = 1f) {
            if(value < min) 
                value = min;
            else if(value > max) 
                value = max;
            return value;
        }

        public static bool operator ==(ColorAnswer op1, ColorAnswer op2) {
            if(op1.Use255Scale != op2.Use255Scale)
                op2.Use255Scale = op1.Use255Scale;

            return (op1._r == op2._r) && (op1._g == op2._g) && (op1._b == op2._b) && (op1._a == op2._a);

            //if(op1.Use255Scale == op2.Use255Scale) {
            //    return (op1._r == op2._r) && (op1._g == op2._g) && (op1._b == op2._b) && (op1._a == op2._a);
            //}
            //else {
            //    op2.Use255Scale = op1.Use255Scale;
            //    return (op1._r == op2._r) && ( op1._g == op2._g) && ( op1._b == op2._b) && ( op1._a == op2._a);
            //}
        } 
        //public static bool operator ==(ColorAnswer op1, ColorAnswer op2)
        //    => (op1._r == op2._r) && (op1._g == op2._g) && (op1._b == op2._b) && (op1._a == op2._a);

        public static ColorAnswer operator + (ColorAnswer op1, ColorAnswer op2) {
            if(op1.Use255Scale != op2.Use255Scale)
                op2.Use255Scale= op1.Use255Scale;

            return new ColorAnswer(op1._r + op2._r, op1._g + op2._g, op1._b + op2._b, op1._a + op2._a); 
        }

        public static bool operator !=(ColorAnswer op1, ColorAnswer op2)
            => !(op1 == op2);

        //public static ColorAnswer operator +(ColorAnswer op1, ColorAnswer op2)
        //    => new ColorAnswer(op1._r + op2._r, op1._g + op2._g, op2._b + op2._b, op1._a + op2._a);


        public static ColorAnswer operator -(ColorAnswer op1, ColorAnswer op2) {
            if (op1.Use255Scale != op2.Use255Scale)
                op2.Use255Scale = op1.Use255Scale;

            return new ColorAnswer(op1._r - op2._r, op1._g - op2._g, op1._b - op2._b, op1._a - op2._a);
        }
        //public static ColorAnswer operator -(ColorAnswer op1, ColorAnswer op2)
        //   => new ColorAnswer(op1._r - op2._r, op1._g - op2._g, op2._b - op2._b, op1._a - op2._a);



    }
}
