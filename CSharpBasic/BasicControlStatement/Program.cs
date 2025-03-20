namespace BasicControlStatement {
    internal class Program {
        static void Main(string[] args) {
            // 조건문
            // if문 : 조건에 논리값이 들어감
            // if의 조건이 참인 경우에만 구현부 실행
            //if (조건1) {
            //     조건1이 참일 때 실행할 내용
            //}
            //else if(조건2) {
            //     조건1이 거짓이고 조건 2가 참일 때 실행할 내용
            //}
            //else { 
            //     상위 조건들이 모두 거짓일 때 실행할 내용
            //}

            int a = 3;

            // 주석 여기 쓰는거 O
            if (a == 3) // 주석 여기 쓰는거 X
                Console.WriteLine("a가 3이라는디요");
            // 구현부가 한 줄이면 중괄호 생략 가능
            // else if 혹은 else 문이 따라 붙으면서 중괄호로 구현부가 정의되었더면 중괄호 생략 X
            if (a < 3)
                Console.WriteLine("a가 3보다 작다는디요");
            else {
                if (a > 3) {
                    Console.WriteLine("a가 3보다 크다는디요");
                }
                else {
                    Console.WriteLine("a가 3이라는디요");
                }
            }
            // 이렇게 작성 금지
            // format 유지할 것

            // swich문
            //string food = Console.ReadLine();

            //switch (food) {
            //    case "Pizza":
            //    case "Hamburger":
            //    case "Pasta":
            //        Console.WriteLine($"{food} (은)는 주문 가능합니다.");
            //        break; // break문 : 현재 구문을 빠져나오는 구문
            //    default:
            //        Console.WriteLine($"{food} (은)는 주문 불가능합니다.");
            //        break;
            //}

            // for문
            //for (반복 시작 전에 실행할 연산; 반복 구문을 실행하기 위한 조건; 반복 구문 완료 후 실행할 연산) { 

            //}

            for (int i = 0; i < 5; i++)
                Console.WriteLine($"카운팅... {i}");

            // 무한반복문
            for(int i = 2; i <= 9; i++) 
                Console.Write($"{i} 단: ");

            Console.WriteLine();

            for (int i = 1; i <= 9; i++) {
                for (int j = 2; i <= 9; i++) {
                    Console.Write($"{i} * {i} = {i * i}");
                }
                Console.WriteLine();
            }

            int sum = 0;

            for(int i = 1; i <= 100; i++) {
                if (i % 3 == 0) {
                    continue; 
                }
                sum += i;
            }

            // while 문
            // 조건이 참일 경우 반복
            int count = 0;

            //while (true) {
            //    Console.WriteLine($"카운팅...{count}") ;
            //    count++;
            //}

            int evenSum = 0;
            count = 1;

            while(count <= 100) {
                if(count % 2 == 0) {
                    evenSum += count;
                }
                count++;
            }
            Console.WriteLine($"1 ~ 100 짝수 합: {evenSum}");

            // 피보나치 수열 : n = {n-1} + {n-2}
            int t = 1;
            int t_1 = 0;

            while (t <= 20) {
                Console.WriteLine($"{t}");
                int next = t + t_1;
                t_1 = t;
                t = next;
            }

            // do-while문
            // 대부분 while문으로 대체 가능함. 특수한 알고리즘 작성해야하는 경우를 제외하고 잘 안 씀
            do {

            }while(true);
        
        N003:
            // go-to 문
            int errorcode = int.Parse(Console.ReadLine());

            if (errorcode == -1)
                goto N001;

            else if (errorcode == -2)
                goto N002;
            else
                goto N003;

        N001:
            Console.WriteLine("ERROR 1");
        N002:
            Console.WriteLine("ERROR 2");

        }
    }
}
