using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSample
{
    class Pigeon
    {
        public int AverageLifespan => _averageLifespan;

        int _averageLifespan;

        public void Fly() {
            Console.WriteLine("비둘기. 날다");
        }

        public void Walk() {
            Console.WriteLine("비둘기. 걷다");
        }
    }
}
