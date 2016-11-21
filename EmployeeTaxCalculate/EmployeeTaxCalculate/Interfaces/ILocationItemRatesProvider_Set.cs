using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public interface ILocationItemRatesProvider_Set
    {
        void SetLocationItemRates(string locationName, IList<ItemRates> itemRates);
    }
}
