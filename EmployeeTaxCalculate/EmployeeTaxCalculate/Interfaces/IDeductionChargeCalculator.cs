using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public interface IDeductionChargeCalculator
    {
        IList<ItemDeduction> CalculateDeductions(decimal grossAmount, IList<ItemRates> itemRatesList);
    }
}
