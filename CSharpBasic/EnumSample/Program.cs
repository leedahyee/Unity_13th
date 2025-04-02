/*
 * enum : 열거형 사용지정의 자료형을 정의하기 위한 키워드
 */

namespace EnumSample {
    /*
     * c#의 enum 타입은 기본적으로 int 값으로 취급
     * enum 정의시 0 값 자리는 의밈없는 default 로 설정함
     */
    enum State : ushort {
        None,
        Move,
        InAir,
        Attack = 100,
        Skill1,
        Skill2,
    }
    [Flags] // 현재 enum의 ToString()으로 문자열 반환하는 함수에서 모든 플래그의 요소들을 문자열로 바꿔주는 특
    enum Layers {
        Nothing         = 0 << 0, // 00000000
        Ground          = 1 << 0, // 00000001
        Enemy           = 1 << 1, // 00000010
        Player          = 1 << 2, // 00000100
        Interactable    = 1 << 3, // 00001000
    }

    internal class Program {
        static void Main(string[] args) {
            Layers targetLayer = Layers.Enemy | Layers.Interactable;

            Layers collisionLayerMask = Layers.Ground | Layers.Enemy;   

            // 충돌 가능
            if ((targetLayer & collisionLayerMask) > 0) {
                // 충돌 처리
            }

            while (true) {
                State currentState = (State)Enum.Parse(typeof(State), Console.ReadLine()); // Enum 클래스 : enum 타입 관련 편의 기능들을 가지고 있음

                switch (currentState) {
                    case State.None:
                        Console.WriteLine("암것도안하는중");
                        break;
                    case State.Move:
                        Console.WriteLine("이동중");
                        break;
                    case State.InAir:
                        Console.WriteLine("공중에뜸");
                        break;
                    case State.Attack:
                        Console.WriteLine("공격중");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
