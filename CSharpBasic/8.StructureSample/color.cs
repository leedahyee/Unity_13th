using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.StructureSample
{
    struct Color {

        const float MAX = 255.0f;
        const float MIN = 0.0f;

        private float _r, _g, _b, _a;
        private bool _useNormalizedScale;

        public Color(float r, float g, float b, float a) {
            _useNormalizedScale = false;  // 기본값: 0 ~ 255 범위

            if (r < MIN || r > MAX || g < MIN || g > MAX || b < MIN || b > MAX || a < MIN || a > MAX)
                throw new ArgumentOutOfRangeException("RGBa 값은 0 ~ 255 범위여야 합니다.");

            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }

        public Color(float r, float g, float b, float a, bool useNormalizedScale) {
            _useNormalizedScale = useNormalizedScale;

            if (useNormalizedScale) {
                if (r < MIN || r > MAX || g < MIN || g > MAX || b < MIN || b > MAX || a < MIN || a > MAX)
                    throw new ArgumentOutOfRangeException("RGBa 값은 0 ~ 255 범위여야 합니다.");

                _r = r / MAX;
                _g = g / MAX;
                _b = b / MAX;
                _a = a / MAX;
            }
            else {
                if (r < MIN || r > MAX || g < MIN || g > MAX || b < MIN || b > MAX || a < MIN || a > MAX)
                    throw new ArgumentOutOfRangeException("RGBa 값은 0 ~ 255 범위여야 합니다.");
                _r = r;
                _g = g;
                _b = b;
                _a = a;
            }
        }


        public float R {
            get {
                if (_useNormalizedScale)
                    return _r / MAX;
                return _r;
            }
            set { _r = value; }
        }

        public float G {
            get { 
                if( _useNormalizedScale)
                    return _g / MAX;
                return _g;
            }
            set { _g = value; }
        }

        public float B {
            get { 
                if(_useNormalizedScale)
                    return _b / MAX;
                return _b;
            }
            set { _b = value; }
        }

        public float A {
            get { 
                if(_useNormalizedScale)
                    return _a / MAX;
                return _a;
            }
            set { _a = value; }
        }


        // 색상 프리셋
        public static Color White => new Color(MAX, MAX, MAX, MAX, false);
        public static Color Black => new Color(0f, 0f, 0f, MAX, false);
        public static Color Red => new Color(MAX, 0f, 0f, MAX, false);
        public static Color Green => new Color(0f, MAX, 0f, MAX, false);
        public static Color Blue => new Color(0f, 0f, MAX, MAX, false);



        public void SetNormalizedScale(bool useNormalizedScale) {
            _useNormalizedScale = useNormalizedScale;

            if (_useNormalizedScale) {
                _r /= MAX;  // 0~255 범위를 0~1로 변환
                _g /= MAX;
                _b /= MAX;
                _a /= MAX;
            }
            else {
                _r *= MAX;  // 0~1 범위를 0~255로 변환
                _g *= MAX;
                _b *= MAX;
                _a *= MAX;
            }
        }


        // 연산자 오버로딩
        public static Color operator +(Color cr1, Color cr2)
            => new Color(cr1._r + cr2._r, cr1._g + cr2._g, cr1._b+ cr2._b, cr1._a + cr2._a);
        public static Color operator -(Color cr1, Color cr2)
        => new Color(cr1._r - cr2._r, cr1._g - cr2._g, cr1._b - cr2._b, cr1._a - cr2._a);
        public static Color operator /(Color cr1, Color cr2)
            => new Color(cr1._r / cr2._r, cr1._g / cr2._g, cr1._b / cr2._b, cr1._a / cr2._a);
        public static Color operator *(Color cr1, Color cr2)
            => new Color(cr1._r * cr2._r, cr1._g * cr2._g, cr1._b * cr2._b, cr1._a * cr2._a);

        // 비교 연산자
        public static bool operator ==(Color cr1, Color cr2)
                => cr1._r == cr2._r && cr1._g == cr2._g && cr1._b == cr2._b && cr1._a == cr2._a;
        public static bool operator !=(Color cr1, Color cr2)
            => !(cr1 == cr2);
    }
}
