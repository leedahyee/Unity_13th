/*
 * 클래스를 디자인 할 때는 :
 * 
 * 1. 캡슐화
 * 객프는 객체간의 상호작용(인터페이스)을 지향하는 프로그래밍 방식이기 때문에
 * 외부에서 접근하기 위한 인터페이스를 (public 프로퍼티, 메서드) 제공하며, 내부적으로 보호되는 데이터 및 로직을 위한 메서드를 구현
 * 
 * 
 */


namespace ClassSample {
    internal class Program {
        static void Main(string[] args) {
            // 클래스는 참조타입
            // new 생성자 호출시 heap에 객체 동적 할당 후 생성된 객체의 참조 반환

            // 클래스 생성자 오버로드를 따로 정의하지 않으면
            // 멤버변수를 초기값대로 초기화하는 public한 생성자가 기본값으로 사용된다
            Eagle eagle = new Eagle("nana");
            eagle.Fly();
            eagle.PrintName();
            Pigeon pigeon = new Pigeon("dada");
            pigeon.Walk();
            pigeon.PrintName();

            Bird bird1 = pigeon; // 클래스 상속받은 기반타입으로 암시적 형변환이 가능하다
            // 주의할 것은, 기반 타입에 구현된 변수 범위까지만 접근한다는 의미를 주의해야한다.
            // 데이터 소실의 위험이 없기 떄문에 암시적 형변환이 일어남
            // Bird bird1 = (Bird)pigeon; 이렇게 생략됨

            Bird[] birds = new Bird[3];
            birds[0] = new Eagle("촤강매");
            birds[1] = new Pigeon("지존구구");
            birds[2] = new Pigeon("구구단");

            for (int i = 0; i < birds.Length; i++) {
                birds[i].Fly();
                birds[i].PrintName();
            }

            // C#의 모든 객체는 생성자 내부에 타입정보를 가리키는 포인터가 할당됨
            // Reflection - 런타임 중에 메타데이터에 접근하는 기능
            object obj = new Pigeon("최강구구"); // 기반 타입으로는 암시적 형변환 가능
            Pigeon pigeon1 = (Pigeon)obj; // 하위타입으로는 '확실한' 경우에만 명시적 형변환 해시 사용

            // is 키워드 : 왼쪽 피연산자의 타입이 오른쪽 피연산자로 형변환이 가능한 경우
            if (obj is Eagle) {
                Eagle eagle1= (Eagle)obj;
                eagle1.PrintName();
                // 둘이 같은거임
                ((Eagle)obj).PrintName();
            }

            // is 키워드 패턴 매칭
            if (obj is Pigeon bird) {
                bird.PrintName();
            }

            // as 키워드 : 왼쪽 피연산자를 오른쪽 피연산자 타입으로 형변환 시도 후, 형변환 성공시 변환된 타입 참조 반환, 실패시 null 반환
            pigeon = obj as Pigeon;
        }
    }
}
