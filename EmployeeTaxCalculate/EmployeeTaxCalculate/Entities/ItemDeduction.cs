using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public class ItemDeduction
    {
        public string DeductionItemName { get; set; }
        public decimal DeductionCharge { get; set; }
        public ItemDeduction(string deductionItemName, decimal deductionCharge)
        {
            DeductionItemName = deductionItemName;
            DeductionCharge = deductionCharge;
        }
    }
}
