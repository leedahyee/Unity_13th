using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.StructureSample
{
    static class Vector3Extensions // static을 사용함으로써 개념을 정의하기 위한 클래스가 됨
    {
        public static float Dot(this Vector3 op1, Vector3 op2) { // op1에 대해서는 직접 파라미터 넘기는 것처럼 쓰지 않고 마치 객체처럼 쓸수 있다
            return (op1.X * op2.X) + (op1.Y * op2.Y) + (op1.Z * op2.Z);
        }
    }
}
