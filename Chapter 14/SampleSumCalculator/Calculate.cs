using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSumCalculator
{
    public class Calculate : ICalculate
    {
        private int NumberA { get; set; }
        private int NumberB { get; set; }

        public Calculate(int numberA, int numberB)
        {
            this.NumberA = numberA;
            this.NumberB = numberB;

        }

        public int Sum() { return NumberA + NumberB; }
    }
}
