/*
 * sbstract class (추상 클래스)
 * 추상화를 위한 클래스타입을 정의하는 것이므로, 인스턴스화가 불가능하다.
 * 
 * 추상화를 할때는, 하위에서 해당 멤버를 구현하지 않을 경우를 만들어서는 안되는것이 원칙
 */

// + : public , - : private, # : protacted
namespace ClassSample
{
    // C#에서 모든 타입은 object타입으로 형변환이 가능하다
    // 값 타입은 다 구조체로 헨들링
    // 참조 타입은 다 클래스로 헨들링
    abstract class Bird : object
    {
        // 추상클래스에서도 생성자는 정의 가능하지만, 이 생성자를 직접 호출할 수 없다. 즉, new Bird(string name) 호출 안됨
        public Bird (string name) {
            name = _name;
        }

        // 추상화 클래스는 추상적이지 않은것도 정의 가능
        public abstract int AverageLifespan { get; } // 평균수명에 대한 멤버변수 같은게 꼭 있을 필요는 없는데 어쨌는 외부에서 평균수명을 읽는 기능은 있어야함

        public string Name => _name; // 추상클래스라고 해서 모든 기능을 추상화 해야하는것은 아니다

        protected string _name; // 이 클래스가 추상적이라고해도, 만약 이름이라는 데이터가 반드시 있어야한다면 멤버 변수 정의 가능

        public abstract void Fly();
        public abstract void Walk();

        // virtual : 가상 키워드
        // 구현부를 작성 했으나, 자식이 재정의 할수 있도록 명시하는 키워드
        public virtual void PrintName() {
            Console.WriteLine($"제 이름은 {_name}입니다");
        }
    }
}
