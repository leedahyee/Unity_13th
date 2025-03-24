using System; // using 키워드 : 특정 namespace를 현재 파일에 사용하겠다

namespace FirstProject { 
    /// <summary>
    /// 프로그램 기본 정의
    /// </summary>
    internal class Program {
        // internal : 동일한 어셈블리 안에서 접근 제한 하기 위한 키워드
        // 키워드(예약어) : 시스템에 사용되기 위해 예약된 단어로, 개발자가 임의로 사용할 수 없는 이름이다

        // static : 정적 키워드
        // 런타임 중에 동적으로 할당할 수 없다
        // 변수를 선언할때는 얼마만큼의 메모리공간을 어떤 형태로 할당해서 사용할 것인지 명시를 해줘야 CPU가 연산할 수 있음

        // static 멤버 : data/bss 영역의 데이터를 활용하는 멤버
        // instance 멤버 : heap/stack 영역에 새로 할당된 데이터를 활용하는 멤버

        // static 멤버함수가 instance 멤버는 접근하지 못함
        // 왜냐하면 어떤 객체의 멤버일지 (누구의 이름일지) 컴파일러가 어떻게 읾?
        // 하지만 파라미터로 인스턴스 참조 받는거는 그냥 값만 넘기면 되는거니까 상관없음

        // 4 = 2^2 * 1 + 2^1 * 0 + 2^0 = 100_2
        
        // char 'P' = 80_10 = 2^6 * 1 + 2^4 * 1 = 00000000 01010000

        // bit : 0과 1의 2진수 표현 단위
        // byte : 정보 처리의 최소 단위 (8bit)

        // C#의 자료형
        static int _num1 = -4; // 4byte 부호 있는 정수형
        static uint _num2 = 2; // 4byte 부호 없는 정수형. 초기값이 있으므로 data 영역에 할당됨
        static short _num3; // 2byte 부호 있는 정수형. 초기값이 없으므로 bss 영역에 들어감
        static ushort _num4; // 2byte 부호 없는 정수형
        static long _num5; // 8byte 부호 있는 정수형
        static ulong _num6; // 8byte 부호 없는 정수형
        static float _num7; // 4byte 실수형
        static double _num8; // 8byte 실수형
        static bool _num9; // 1byte 논리형
        static char _char1; // 2byte 문자형 (ASCII 코드표에 따른 정수 취급)
        static string _string1; // 문자열형, 문자갯수 * 2byte + 1byt(null byte, 문자열의 끝을 암시)
        static object _object1; // 객체형, C#의 모든 자료형의 기반 타입

        // 이름 규칙
        // Pascalcase
        // camelcase
        // snake_case
        // UPPER_SNZKE_CASE

        // 상수 이름 규칙은 공식 문거에세는 보통 PascalCase 권장. 근데 보통 UPPER_SNAKE_CASE를 사용해 가독성을 높임
        const int MAX_CLIENTS = 10;
        static readonly float MaxHp; 

        /// <summary>
        /// 프로그램 실행시 첫 진입점 함수
        /// </summary>
        /// <param name="args"> 프로그램 시작 옵셥 </param>
        static void Main(string[] args) { // static = 동적으로 할당 할 수 없음. 즉, heap영역에 할당할 수 없다
            // string[] args : 실행할 때 옵션을 부여하기 위해 존재

            _num1 = MAX_CLIENTS;
            _num7 = MaxHp;
            /*
             * Hello World 출력
             */
            Console.WriteLine("Hello, World!"); // 출력문 끝에 줄바꿈
            Console.WriteLine("{1} {3} {2} {0} {0}", "luka", "my", "is", "name");
            Console.WriteLine(@"\'1\'\r"); 

            // 형변환
            // - 명시적 형변환 : 다른 자료형으로 취급해야한다고 명시해서 변환 (컴파일러가 안전하지 않다고 판단하는 경우)
            // 취급하는 값 종류는 동일하나 크기가 다를 경우에 큰 값을 작은 공간에 넣으려고 한다면 이것은 데이터 소실 위험이 있으므로 변환 해야함
            int a = (int)314; // 8byte 정수 데이터를 4byte 정수 공간에 대입하면 
            int b = (int)3.14; // 4byte 실수 데이터를 4byte 정수 공간에 대입하려면 소수 부분 소실 위험 있음
            // - 암시적 형변환 : 개발자가 따로 명시하지 않아도 연산과정에서 형변환이 일어나는 변환 (컴파일러가 안전하다고 판단하는 경우)
            // 취급하는 값 종류가 동일하고, 작은 값을 큰 공간에 넣으려고 할 때

        }
    }
}
