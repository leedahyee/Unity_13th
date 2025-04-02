using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculatorProject {
    struct Fraction : IPrintable {
        public int Numerator { get; }
        public int Denominator { get; }


    public Fraction(int numerator, int denominator) {
            if (denominator == 0) {
                Console.WriteLine("분모가 0이 될 수 없습니다. 값을 1로 설정합니다.");
                denominator = 1;
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        // 최대공약수 구하는 식
        private int GDC(int a, int b) {
            a = Numerator; // 수정
            b = Denominator; // 수정

            while (b != 0) {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a); // 최대공약수는 항상 양수로 설정
        }

        // GDC 사용해서 기약분수로 만들기
        public Fraction Reduce() {
            // 분모가 0일 경우 삭제
            int gdc = GDC(Numerator, Denominator);

            // gcd가 0이 아닐 때만 return으로 수정
            if(gdc != 0) 
                return new Fraction(Numerator / gdc, Denominator / gdc);

            return this; // 수정
        }

        // Fration "분자 / 분모" 형태로 출력
        public void PrintInfo() {
            Console.WriteLine($"{Numerator}/{Denominator} ");
        }

        // 연산자 오버로딩
        public static Fraction operator +(Fraction a, Fraction b)
        => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator).Reduce();

        public static Fraction operator -(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator).Reduce();

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator).Reduce();

        public static Fraction operator /(Fraction a, Fraction b) {
            if (b.Numerator == 0) {
                throw new DivideByZeroException("분모가 0이 될 수 없습니다.");
            }
            int numerator = a.Numerator * b.Denominator;
            int denominator = a.Denominator * b.Numerator;

            return new Fraction(numerator, denominator).Reduce();
        }

        public static bool operator ==(Fraction a, Fraction b)
            => a.Numerator * b.Denominator == b.Numerator * a.Denominator;

        public static bool operator !=(Fraction a, Fraction b)
            => !(a == b);

        public static Fraction operator ~(Fraction a)
            => new Fraction(~a.Denominator, a.Numerator); // 분자의 비트 반전
    }

}