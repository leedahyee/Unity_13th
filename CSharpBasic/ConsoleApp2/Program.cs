using FractionCalculatorProject;

class Program {
    static void Main() {
        FractionCalculator fractionCalculator = new FractionCalculator();
        Fraction[] fractions = new Fraction[5];
        bool running = true;


    Console.WriteLine("분수 계산기 프로그램입니다.");
        while (running) {
            Console.WriteLine();
            Console.WriteLine("메뉴에서 원하는 항목을 선택하세요.");
            Console.WriteLine("1. 분수 입력");
            Console.WriteLine("2. 연산 수행");
            Console.WriteLine("3. 분수 비교");
            Console.WriteLine("4. 비트 연산");
            Console.WriteLine("5. 저장되어 있는 모든 분수 출력");
            Console.WriteLine("6. 프로그램 종료");
            Console.Write("번호를 입력해주세요: ");

            if (!int.TryParse(Console.ReadLine(), out int choice)) {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요. (예: 1)");
                continue;
            }

            switch (choice) {
                case 1:
                    fractionCalculator.Add(new Fraction(0, 1));
                    break;
                case 2:
                    if (fractions.Length < 2) {
                        Console.WriteLine("연산을 수행하려면 최소 두 개의 분수가 필요합니다.");
                    }
                    else {
                        fractionCalculator.PerformOperations(fractions[0], fractions[1]);
                    }
                    break;
                case 3:
                    if (fractions.Length < 2) {
                        Console.WriteLine("비교를 수행하려면 최소 두 개의 분수가 필요합니다.");
                    }
                    else {
                        fractionCalculator.fractionCompare(fractions[0], fractions[1]);
                    }
                    break;
                case 4:
                    if (fractions.Length < 2) {
                        Console.WriteLine("비트 연산을 수행하려면 최소 두 개의 분수가 필요합니다.");
                    }
                    else {
                        fractionCalculator.fracionBitOperation(fractions[0], fractions[1]);
                    }
                    break;
                case 5:
                    fractionCalculator.PrintAll();
                    break;
                case 6:
                    Console.WriteLine("프로그램을 종료합니다.");
                    running = false;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    break;
            }
        }
    }

}