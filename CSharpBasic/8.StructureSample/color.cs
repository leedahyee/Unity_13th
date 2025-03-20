using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.StructureSample
{
    struct color {

        const float MAX = 255.0f;

        public color() {
            this._x;
        }


        public color(float x, float y, float z) {
            _x = x;
            _y = y;
            _z = z;
        }

        private float _x, _y, _z;

        public float GetX { get; set; }

        public float GetY { get; set; }

        public int GetZ { get; set; }



        public static color White => new color(MAX, MAX, MAX);

        public static color Green => new color(0f, MAX, 0f);

        public static color Blue => new color(0f, 0f, MAX);

        public static color Red => new color(MAX,0f,0f);

        public static color Black => new color(0f, 0f, 0f);


        public static color operator /(color op1, float op2)
            => new color(op1._x / op2, op1._y / op2, op1._z / op2);
        public static color operator /(color op1, int op2)
            => new color(op1._x / op2, op1._y / op2, op1._z / op2);
        public static color operator *(color op1, float op2)
            => new color(op1._x / op2, op1._y / op2, op1._z / op2);
        public static color operator *(color op1, int op2)
            => new color(op1._x / op2, op1._y / op2, op1._z / op2);
        public static bool operator ==(color op1, color op2)
            => (op1._x == op2._x) && (op1._y == op2._y) && (op1._z == op2._z);
        public static bool operator !=(color op1, color op2)
            => !(op1 == op2);
        public static color operator +(color op1, color op2)
            => new color(op1._x + op2, op1._y + op2, op1._z + 2);

        public bool useNormalizedScale() {

        }
    }
}
