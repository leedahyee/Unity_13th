using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeOOP;

namespace PracticeOOP
{
    class Mushroom : Enemy, IAttacker {

        public Type Field;

        public Mushroom(string name, int hpMax,int attackForce) : base(name, hpMax) {
            AttackerFource = attackForce;
        }

        public int AttackerFource { get; private set; }

        public override char Symbol => '◆';

        public override ConsoleColor SymbolColor => ConsoleColor.DarkRed;                  

        public void Attack(IDamageable target) {
            target.Damage(this,AttackerFource);
        }
    }
}
