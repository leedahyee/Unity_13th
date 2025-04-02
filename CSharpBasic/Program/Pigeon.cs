using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSample
{
    class Pigeon : Bird {
        public Pigeon(string name) : base(name) {
        }

        public override int AverageLifespan => 15;

        public override void Fly() {
            Console.WriteLine($"{_name}(비둘기), 날다");
        }

        public override void Walk() {
            Console.WriteLine($"{_name}(비둘기), 걷다");
        }

        public override void PrintName() {
            base.PrintName();
            Console.WriteLine("구구..."); // virtual 키워드를 사용하면 추가 가능
        }
    }
}
