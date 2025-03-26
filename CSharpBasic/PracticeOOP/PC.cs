namespace PracticeOOP
{
    abstract class PC : Character, IAttacker
    {
        // base 생성자 오버로드가 파라미터를 가진다면, 자식 클래스는 생성자 오버로드를 정의하여 base 생성자의 파라미터에 인수를 전달해야한다
        public PC(string name, int hpMax,int attackForce) : base(name, hpMax) {
            AttackerFource = attackForce;
        }

        public CharacterClass CurrentClass { get; private set; }

        public int AttackerFource {  get; private set; }

        public void Attack(IDamageable target) {
            target.Damage(this, AttackerFource);
        }
    }
}
