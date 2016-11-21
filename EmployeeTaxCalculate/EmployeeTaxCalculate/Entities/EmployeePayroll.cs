using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public class EmployeePayroll
    {
        private decimal hours { get; set; }
        private decimal rate { get; set; }
        public string Location { get; private set; }
        public decimal GrossAmount { get; private set; }

        public EmployeePayroll(decimal hours, decimal rate, string location)
        {
            this.hours = hours;
            this.rate = rate;
            GrossAmount = hours * rate;
            Location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location.ToLower());
        }

        public EmployeePayroll(decimal grossAmount, string location)
        {
            GrossAmount = grossAmount;
            Location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location.ToLower());
        }
    }
}
