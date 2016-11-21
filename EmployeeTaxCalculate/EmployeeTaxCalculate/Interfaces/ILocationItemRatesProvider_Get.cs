using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public interface ILocationItemRatesProvider_Get
    {
        IList<ItemRates> GetLocationItemRates(string location);
        bool IsLocationExisted(string location);
    }
}
