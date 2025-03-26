using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSample {
    class Eagle : Bird {
        // base : 기반 타입 참조 키워드
        // 여기서는 Bird의 멤버에 접근할 때 사용
        public Eagle(string name) : base(name) {
        }

        public override int AverageLifespan => 10;

        public override void Fly() {
            Console.WriteLine($"{_name}(매), 날다");
        }

        public override void Walk() {
            Console.WriteLine($"{_name}(매), 걷다");
        }

        public override void PrintName() {
            base.PrintName();
        }
    }
}
