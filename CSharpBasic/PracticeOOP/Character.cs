
namespace PracticeOOP {
    abstract class Character : GameObject, IDamageable {
        public Character(string name, int hpMax) {
            Name = name;
            HpMax = hpMax;
            Hp = hpMax;
        }


        public string Name { get; private set; }

        public int HpMax { get; private set; }

        public int Hp { get; protected set; }


        public virtual void Damage(IAttacker attacker, int amount) {
            Hp -= amount;
        }
    }
}