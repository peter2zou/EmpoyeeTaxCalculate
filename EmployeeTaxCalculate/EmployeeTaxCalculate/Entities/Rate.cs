using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public class Rate
    {
        public decimal MinValue { get; private set; }
        public decimal MaxValue { get; private set; }
        public decimal Percent { get; set; }

        public Rate(decimal min, decimal max, decimal percent)
        {
            MinValue = min;
            MaxValue = max;
            Percent = percent;
        }
    }
}
