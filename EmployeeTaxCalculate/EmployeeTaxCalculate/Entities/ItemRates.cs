using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public class ItemRates
    {
        public string ItemName { get; set; }
        public IList<Rate> Rates { get; set; }
        public ItemRates(string itemName, IList<Rate> rates)
        {
            ItemName = itemName;
            Rates = rates;
        }
    }
}
