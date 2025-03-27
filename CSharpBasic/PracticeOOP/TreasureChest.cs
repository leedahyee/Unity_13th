
namespace PracticeOOP
{
    class TreasureChest : GameObject, IDamageable
    {
        public TreasureChest(int hpMax) {
            HpMax = hpMax;
            Hp = hpMax;
        }

        public int HpMax { get; private set; }

        public int Hp { 
            get => _hp;
            private set {
                if(value > HpMax)
                    value = HpMax;
                _hp = value;
            } 
        }

        public override char Symbol => '▩';

        public override ConsoleColor SymbolColor => ConsoleColor.Magenta;

        private int _hp;

        private void GiveReward(PC pc) { }

        private void DestroySell() { }

        public void Damage(IAttacker attacker, int amount) {
            if (amount <= 0)
                return;

            if (_hp <= 0)
                return;

            Hp--;

            if (_hp <= 0){
                if(attacker is PC pc) {
                    GiveReward(pc);
                }
                DestroySell();
            }
        }
    }
}
