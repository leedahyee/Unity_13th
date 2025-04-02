namespace Operators {
    internal class Program {
        static void Main(string[] args) {
            int a = 14, b = 6, c = 0; // 변수를 main함수 안에 정의하면 stact 영역에 들어감

            // 산술 연산자
            c = a + b; // 덧셈
            Console.WriteLine($"{a} + {b} = {c}");
            c = a - b; // 뺄셈
            Console.WriteLine($"{a} - {b} = {c}");
            c = a * b; // 곱셈
            Console.WriteLine($"{a} * {b} = {c}");
            c = a / b; // 나눗셈, 정수끼리 나누기할 경우 몫이 반환
            Console.WriteLine($"{a} / {b} = {c}");
            c = a % b; // 나머지셈
            Console.WriteLine($"{a} % {b} = {c}");

            // 복합 대임 연산자
            int tempC = c;
            c += a;
            Console.WriteLine($"{tempC} + {a} = {c}");

            // 증감 연산자
            tempC = c;
            c += 1;
            Console.WriteLine(tempC);
            Console.WriteLine(c++);
            c = 0;
            ++c; // 전위 연산, 결과값 반환
            c++; // 후위 연산, 초기값 반환
            --c; 
            c--;
            // 요즘 날에는 하드웨어 성능이 좋기 때문에 굳이 후위 연산의 성능을 따지지 않지만, 무거운 연산이라면 고려 할 수도 있다.
            // 보통 가독성 때문에 후위 연산을 선호하는 경향이 있다.

            // 관계 연산자
            // 논리값을 반환
            bool result;
            result = a == b; // a & b가 같으면 true, 아니면 false
            result = a != b; // a & b가 다르면 true, 아니면 false
            result = a > b; // a & b보다 크면 true, 아니면 false
            result = a >= b; // a & b보다 크거나 같으면 true, 아니면 false
            result = a < b; // a & b보다 작으면 true, 아니면 false
            result = a <= b; // a & b보다 작거나 같으면 true, 아니면 false

            // 논리 연산자
            bool x1 = true, x2 = false;

            result = x1 & x2; // and 논리 연산, 둘 다 true 일 때만 true 반환
            result = x2 | x1; // or 논리 연산, 둘 중 하나라도 true이면 true 반환
            result = x1 ^ x2; // XOR 논리 연산, 둘 중 한 개만 true이면 true 반환
            result = !x1; // NOT 논리 연산, 피연산자가 true면 false, false면 true 반환
            result = x1 == false; // NOT 논리 연산자가 가독성이 떨어지기 때문에, false 비교연산자로 대체할 수 있음

            // 조건부 논리 연산자
            result = x1 && x2; // 왼쪽 피연산자 결과가 false면 바로 false 반환
            result = x1 || x2; // 왼쪽 피연산자 결과가 true면 바로 true 반환

            // 비트 연산자
            // a = 14 = 00001110
            // b = 6 = 00000110
            // bit and
            // a & b == 00000110 = 6
            c = a & b;
            // bit or
            // a | b == 00001110 = 14
            c = a | b;
            // bit xor
            // a ^ b == 00001000 = 8
            c = a ^ b;
            // bit not
            // ~a == 11110001 = -15
            c = ~a;
            // 2의 보수
            // 2진법 슷자 모두 반전후 +1

            // bit left shift 모든 비트 n칸 왼쪽으로 밀기
            c = a << 2; // 00111000 = 54
            // bit right shift 모든 비트 n칸 오른쪽으로 밀기
            c = a >> 3; // 00000001 = 1

            // 삼항 연산자
            // '?' 왼쪽 값이 true면 ':' 왼쪽 값 반환, 아니면 ':' 오른쪽 값 반환
            // 아주 간단한 if문 대용으로 쓸 수 있지만
            // 아주 간단한 내용에만 사용할 것. 남용하면 가독성 떨어짐
            if (c > 3) {
                c = 10;
            }
            else {
                c = 0;
            }

            c = c > 3 ? 10 : 0;

            // null 병합 연산자
            // '??' 왼쪽 값이 null이 아닐 경우 왼쪽 값 반환, 아니면 오른쪽 값 반환
            string name = "kall";
            string lable = name ?? "(Unknown)";
            Console.WriteLine(lable);

            // null cheak 연산자
            // 대상이 null일 경우 참조 호출 하지 않고 null 반환
            Console.WriteLine($"Length of name is {name?.Length ?? 0}");
        }
    }
}
