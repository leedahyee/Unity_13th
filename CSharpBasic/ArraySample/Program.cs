using System;

namespace ArraySample {
    internal class Program {
        static void Main(string[] args) {
            //// new 키워드 : 샤로 어떤 데이터가 초기화 되었다는 뜻
            //// 배열 생성 방법 : new 자료형[크기]
            //// 배열은 참조 형식
            // int[] arr = new int[5];
            // int[] arr1 = { 3, 4, 2, 7, 1 }; // 요소변 초기값 주고 싶을 때
            //// int[] arr1 = new int[5] { 3, 4, 2, 7, 1 }; 이렇게 작성해도 됨

            //// 배열의 인덱서
            //// 배열에서 특정 번째 요소에 접근할 수 있도록 하는 기능
            //// arr[i] , 배열의 첫 번째 주소에서부터
            //// i * 요소의 자료형 크기만큼 뒤로 가서
            //// 해당 주소부터 자료형 크기만큼 읽거나 쓰기 함
            // arr[0] = 5;
            // arr[1] = 5;
            // arr[2] = 5;
            // arr[3] = 5;
            // arr[4] = 5;

            // for(int i=0; i<arr.Length; i++)
            //    System.Console.WriteLine(arr[i]);

            //// Array 클래스
            //// 배열관련 편의 기능들이 있음
            //Array.Sort(arr);
            //for(int i=0;i<arr.Length; i++) {
            //    System.Console.WriteLine($"arr[i]");
            //}

            //Array.Reverse(arr);

            // Jagged Array
            // 1. 비연속적인 데이터 (캐시 메모리 친화적이 아님)
            // 2. 비연속적이기 때문에 주소 참조가 여러번 일어남
            // 3. 주소 참조가 여러번 일어나기 때문에 많은 비용이 듬
            

            int[][] entries = new int[3][]; // 앞에 (int [])는 배열 참조 변수. 
            // int[3][] : 배열을 참조할 수있는 공간 3개를 만들겠다.
            entries[0] = new int[2];
            entries[1] = new int[4];
            entries[2] = new int[3];

            for (int i = 0; i < entries.Length; i++) {
                for (int j = 0; j < entries[i].Length; j++) {
                    System.Console.Write(entries[i][j]);
                }
                System.Console.WriteLine();
            }

            //2차원 배열
            int[,] map = new int[6, 5] {                
                { 0, 0, 0, 0, 1 },
                { 0, 1, 1, 1, 1 },
                { 0, 0, 0, 1, 1 },
                { 1, 1, 0, 1, 1 },
                { 1, 1, 0, 1, 1 },
                { 1, 1, 0, 0, 2 },
            };

            int playerX = 0, playerY = 0;
            int goalX = 4, goalY = 5;

            map[playerY, playerX] = 3;
            DisplayMap(map);
           

            while (true) {
                ConsoleKeyInfo consoleKeyInfo = System.Console.ReadKey();

                if (TryMovePlayerPosition(map, ref playerX, ref playerY, consoleKeyInfo.Key)) {
                    DisplayMap(map);
                
                   if (playerX == goalX && playerY == goalY) {
                        System.Console.WriteLine("Game over");
                        break;
                   }     
                }
            }
            
        }

        static bool TryMovePlayerPosition(int[,] map, ref int playerX, ref int playerY, ConsoleKey consolekey) {
            int targetX = playerX;
            int targetY = playerY;

            switch (consolekey) {
                case ConsoleKey.UpArrow:
                    targetY -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    targetY += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    targetX -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    targetX += 1;
                    break;
                case ConsoleKey.Escape:
                    return false;
                default:
                    return false;
            }

            // 이동 대상 위치가 맵의 경계를 벗어났는가
            if (targetY < 0 || targetY >= map.GetLength(0))
                return false;
            if(targetX < 0 || targetX >= map.GetLength(1)) 
                return false;

            // 이동 불가능한 타일인지 확인 (벽인지)
            if (map[targetY, targetX] == 1)
                return false;

            // 가존 위치 초기화
            map[playerY, playerX] = 0;
            playerX = targetX;
            playerY = targetY;
            map[playerY, playerX] = 3;

            return true;
        }

        static void DisplayMap(int[,] map) {
            System.Console.Clear();

            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    //if (map[i, j] == 0)
                    //    Console.Write("□ ");
                    //else if (map[i, j] == 1)
                    //    Console.Write("■ ");
                    //else if (map[i, j] == 2)
                    //    Console.Write("☆ ");
                    //else if (map[i, j] == 3)
                    //    Console.Write("▣ ");
                    //else
                    //    throw new Exception("잘못된 값입니다....");

                    switch (map[i, j]) {
                        case 0:
                            System.Console.Write("□ ");
                            break;
                        case 1:
                            System.Console.Write("■ ");
                            break;
                        case 2:
                            System.Console.Write("☆ ");
                            break;
                        case 3:
                            System.Console.Write("▣ ");
                            break;
                        default:
                            throw new Exception("잘못된 값입니다....");
                    }
                }
                System.Console.WriteLine();
            }
        }

        enum MapNode {
            None,
            Path,
            Wall,
            Goal,
            User
        }

        enum Console {
            None,
            Up,
            Down,
            Right,
            Left
        }

    }
}
