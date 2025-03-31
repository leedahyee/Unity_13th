using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculatorProject {
    class FractionCalculator {
        private Fraction[] fractions = new Fraction[5];
        private int count = 0;


    // 분수 추가 함수
        public void Add(Fraction fraction) {
            if (count >= 5) {
                Console.WriteLine("최대 5개의 분수만 저장할 수 있습니다.");
                return;
            }

            Console.Write("추가할 분수의 분자 입력: ");
            int numerator = int.Parse(Console.ReadLine());
            Console.Write("추가할 분수의 분모 입력: ");
            int denominator = int.Parse(Console.ReadLine());

            if (denominator == 0) {
                Console.WriteLine("분모가 0이 될 수 없습니다. 값을 1로 설정합니다.");
                denominator = 1;
            }

            fractions[count++] = new Fraction(numerator, denominator);
            Console.WriteLine("분수가 추가되었습니다.");
        }

        // 저장된 모든 분수 출력
        public void PrintAll() {
            if (count == 0) {
                Console.WriteLine("저장된 분수가 없습니다.");
                return;
            }

            Console.WriteLine("현재 저장된 모든 분수: ");
            for (int i = 0; i < count; i++) {
                fractions[i].PrintInfo();
            }
        }

        // 분수 연산 수행 함수
        public void PerformOperations(Fraction a, Fraction b) {
            Console.WriteLine("수행하고 싶은 연산을 선택하세요. (예: 1)");
            Console.WriteLine("1. 덧셈");
            Console.WriteLine("2. 뺄셈");
            Console.WriteLine("3. 곱셈");
            Console.Write("번호를 입력해주세요: ");
            int select = int.Parse(Console.ReadLine());

            Fraction result = new Fraction();
            switch (select) {
                case 1:
                    result = a + b;
                    break;
                case 2:
                    result = a - b;
                    break;
                case 3:
                    result = a * b;
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }

            if (result.Denominator == 0) {
                Console.WriteLine("연산 결과: 분모가 0이 될 수 없습니다.");
            }
            else {
                Console.WriteLine("연산 결과: ");
                result.PrintInfo();
            }
        }

        public void fractionCompare(Fraction a, Fraction b) {
            if (a == b) {
                Console.WriteLine("두 분수는 같습니다.");
            }
            else {
                Console.WriteLine("두 분수는 다릅니다.");
            }
        }

        public void fracionBitOperation(Fraction a, Fraction b) {
            Fraction result = ~a;
            Console.WriteLine("연산 결과: ");
            result.PrintInfo();
        }

    }

}