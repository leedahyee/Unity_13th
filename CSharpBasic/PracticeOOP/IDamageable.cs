/*
 * interface : 키워드
 * 외부 객체와 상호작용을 위한 기능들을 추상화하기 위한 사용자 정의 자료형을 정의할 때 사용하는 키워드
 * 상호작용이 목적이기 때문에 접근제한자는 public이 기본값이다
 * 기능의 추상화!!!!11!
 * 
 * "기능"의 추상화이므로 데이터를 포함할 수 없다 (즉, 멤버 변수 등 선언 불가능)
 * interface를 상속받은 interface
 */
namespace PracticeOOP
{
    interface IDamageable
    {
        int HpMax {  get; }

        int Hp { get; }
        
        void Damage(IAttacker attacker,int amount);
    }
}
