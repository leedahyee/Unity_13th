using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionSample
{
    class FractionCalculator : IPrintable
    {
        public FractionCalculator(int capacity) {
            _fractions = new Fraction[capacity];

        }


        public int Capacity => _fractions.Length; // 배열의 개수
        
        private Fraction[] _fractions;
        private int _count = 0;


        public Fraction InputFraction() {
            while (true) {
                Console.WriteLine("분수를 입력하세요. (분수/분모)");
                string input = Console.ReadLine(); // readLine하면 string이 반환 됨
                string[] splits = input.Split('/');

                if (splits.Length == 2)
                    continue;

                if(int.TryParse(splits[0], out int numerator) == false)
                    continue;

                if(int .TryParse(splits[1], out int denominator) == false)
                    continue;

                return new Fraction(numerator, denominator);
            }
        }


        public void AddFraction(Fraction fraction) {
            if (_count == _fractions.Length)
                throw new Exception("용량의 범위를 초과하였습니다.");

            _fractions[_count++] = fraction;

        }

        public void Print() {
            for (int i = 0; i < _count; i++) {
                _fractions[_count].Print();
            }
        }



        public bool TryOperation(Fraction a, Fraction b, char operatorChar, out Fraction result) {
            try {
                switch (operatorChar) {
                    case '+':
                        result = a + b;
                        break;
                    case '-':
                        result = a - b;
                        break;
                    case '*':
                        result = a * b;
                        break;
                    case '/':
                        result = a / b;
                        break;
                    default:
                        throw new ArgumentException($"{operatorChar} 는 연산 가능한 입력이 아닙니다.");
                        break;
                }
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
                result = Fraction.Invalid; // default를 넣는 것은 좋은 방식이 아님. 현재 result에는 분자, 분모가 들어있기 때문

                return false;
            }

            return true;
        }

        public void BoxingSimulation(Fraction a, Fraction b) {
            object obj1 = a, obj2 = b;

            Console.WriteLine($"Boxed {a} {(obj1 == obj2 ? "==" : "!=")} Boxed {b}"); // !=

            Console.WriteLine($"Boxed {a} {(obj1.Equals(obj2) ? "equals" : "not equals")} Boxed {b}"); // equals 
        }
    }
}
