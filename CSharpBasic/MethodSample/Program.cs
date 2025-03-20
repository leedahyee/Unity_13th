/*
 *  변수의 형식
 *  값 형식        : 변수 할당한 메모리 공갑에 값을 쓰고 읽는 형식
 *  포인터 형식    : 변수 할당한 메모리 공간에 다른 메모리 주소를 쓰고 읽는 형식
 *  참조 형식      : 변수의 별칭을 지정하는 형식, 변수 할당한 메모리 공간에 다른 메모리 주소를 쓰고 읽긴 하지만, 
 *  개발자가 직접 메모리 주소값을 신경쓰지 않고, 해당 메모리 주소의 데이터만 쓰고 읽기함.
 *  
 *  C#은 개발자 편의를 위해 기본적인 컨셉은 값과 참조형식만 사용하나,
 *  포인터 형식도 사용 가능하다
 *  class : 객체를 설계한 (사용자 정의) 자료형
 *  객체 : 고유한 데이터의 기능을 가진 단위
 */

// Human._name, Human._age -> BSS에 저장
namespace MethodSample {
    //void main() {
    //    int a = 3; // 값 형식 변수
    //    string name = "Hi"; // 참조 형식 변수
    //}

    class Human {
        /*
         * 클래스 내에서
         * 멤버 : 클래스가 포함하고 있는 요소들
         * static이 붙은 멤버    : 전적 멤버
         * static이 안 붙은 멤버 : 인스턴스 멤버
         */

        // 매개변수 name, age
        public Human(string name, int age) {
            _name = name;
            _age = age;
        }

        string _name; // 인스턴스 멤버 변수 : 객체 생성시 힙 영역에 할당한 변수
        static int _age; // 정적 멤버 변수  : 힙 영역에 할당하지 않고 데이터(bss) 영역에 직접 데이터를 쓰고 읽기 위한 변수

        /// <summary>
        /// Non-Static(instance) method (인스턴스 멤버 함수)
        /// </summary>
        /// <returns></returns>

        public string GetName() {
            return _name;
        } 
    }

    internal class Program {
        /// <summary>
        /// Main함수는 static 함수이므로
        /// instance 멤버를 그냥 사용하지 못함
        /// </summary>
        /// <param name="args"></param>

        // main 함수를 계산하기 위한 변수들의 데이터가 stack에 저장됨
        static void Main(string[] args) {
            // 함수내 문자열 리터럴은 함수 호출때마다 동적 할당 되는게 아니고, 어셈블리의 메타데이터와 함께 저장됨
            // CLR이 이 문자의 리터럴을 intern pool에 로드해서 필요할 때마다 참조해서 재사용함
            // intern pool은 managed heap영역에 할당됨>	MethodSample.dll!MethodSample.Program.Main(string[] args) 줄 60	C#

            int num1 = 32341;
            Human human1 = new Human("정하윤", 320); // 동적 할당 
            string humanName = human1.GetName();
            
            Console.WriteLine(humanName);

            num1 = Add(1, 2);

            // out 키워드 : 변수의 참조 전달, 보통 두 개 이상의 값을 반환해야 하는 경우 사용
            if(TryReinforce(70.0,30.0,1,out int result)) {
                Console.WriteLine($"강화 성공 {result} 를 획득했다");
            }
            else {
                Console.WriteLine($"강화 실패 아이템이 파괴되었다...");
            }
            // ref 키워드 : 변수의 참조 전달, 이미 초기화 되어 있는 변수의 값을 업데이트 해야할 때 사용
            int x= 3, y= 4;
            Swap(ref x, ref y);
            Console.WriteLine($"a: {x}, b: {y}");

            Factorial(5);
        }

        // 로컬 = 중괄호로 묶여있는 부분
        
        // 앞에 static을 붙이는 이유
        static int Add(int x, int y) {
            return x + y;
        }
        /*
         *  함수 오버로딩 (같은 이름의 함수를 정의 할 수 있는 기능)
         *  이름이 같아도 파라미터가 다름 다른 함수.
         */
        static long Add(long x, long y) {
            return x + y;
        }

        /// <summary>
        /// 난수확률 시도 함수
        /// </summary>
        /// <param name="percent"> 강화 성공 확률, 성공시 + 1</param>
        /// <param name="greatPercent"> 강화 대성공 확률 0 ~ 100%, 대성공 시 + 2</param>
        /// <param name="target"> 강화할 숫자 </param>
        /// <param name="result"> 강화된 후 결괴 숫자 </param>
        /// <returns> 강화 성공 여부, 강화 실패시 숫자는  0으로 파괴됨 </returns>
        static bool TryReinforce(double percent, double greatPercent, int target, out int result) {
            Random random = new Random();

            // 강화 성공
            if(random.NextDouble() * 100 < percent) {
                if (random.NextDouble() * 100< greatPercent) {
                    result = target + 2;
                }
                else {
                    result = target + 1;
                }
                return true;
            }
            // 깅화 실패, 아이템 파괴 (숫자 파괴)
            else {
                result = 0;
                return false;
            }
        }

        // Swap 기능 함수로 묶어서 모듈화
        // a, b의 값만 전달됨. main 함수에 있는 a와 b를 건들 수 없음
        static void Swap(ref int x, ref int y) {
            int temp = x;
            x = y;
            y = temp;
        }

        static int Factorial(int n) {
            if (n < 2)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}

// 디버깅 하는 습관 ...