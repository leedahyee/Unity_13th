using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionSample
{
    struct Fraction : IPrintable {
        public Fraction(int numerator, int denominator) {
            if (denominator == 0) {
                Console.ForegroundColor = ConsoleColor.Red; // 빨간색으로 출력
                Console.WriteLine("분모가 0이 될 수 없습니다. 분모를 1로 설정합니다.");
                Console.ResetColor();
                denominator = 1;
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public static Fraction Invalid => new Fraction { Numerator = 0, Denominator = 0 };

        public int Numerator; // 분자
        public int Denominator; // 분모


        /// <summary>
        /// 기약 분수
        /// </summary>
        public Fraction Reduce() {
            int gcd = GCD();

            if (gcd != 0)
                return new Fraction(Numerator / gcd, Denominator / gcd);

            return this;
        }

        /// <summary>
        /// 최대공약수
        /// </summary>
        private int GCD() {
            // 무조건 양수
            int a = Math.Abs(Numerator);
            int b = Math.Abs(Denominator);
            int temp = 0;

            // a가 b보다 작은 경우 둘의 자리를 바꿈
            if (a < b) {
                temp = a;
                b = a;
                a = temp;
            }

            while (b != 0) {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public void Print() {
            Console.WriteLine($"{Numerator}/{Denominator}");
        }

        public override string ToString() {
            return $"{Numerator}/{Denominator}";
        }


        public static Fraction operator +(Fraction a, Fraction b) {
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;

            return new Fraction(numerator, denominator).Reduce(); // 기약 분수로 반환
        }

        public static Fraction operator -(Fraction a, Fraction b) {
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;

            return new Fraction(numerator, denominator).Reduce();
        }

        public static Fraction operator *(Fraction a, Fraction b) {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b) {
            if (b.Numerator == 0) {
                throw new Exception("분자가 0인 분수로 나누기로 시도했습니다.");
            }

            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static bool operator ==(Fraction a, Fraction b) {
            a = a.Reduce();
            b = b.Reduce();
            return (a.Numerator == b.Numerator) && (a.Denominator == b.Denominator);
        }

        public static bool operator !=(Fraction a, Fraction b) 
            => !(a == b);

        public static Fraction operator ~(Fraction a)
            => new Fraction(~a.Denominator, a.Numerator);
    }
}
