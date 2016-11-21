using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public class EmployeePayrollManager
    {
        private EmployeePayroll _employeePayroll=null;
        private ILocationItemRatesProvider_Get _rateProvider=null;
        private IDeductionChargeCalculator _chargeCalculator=null;

        /// <summary>
        /// Construnctor: Dependency Injection. Can use 3rd party DI container like Unity.
        /// </summary>
        /// <param name="employeePayroll">EmployeePayroll object</param>
        /// <param name="rateProvider">ILocationItemRatesProvider type object</param>
        /// <param name="chargeCalculator">IDeductionChargeCalculator type object </param>
        public EmployeePayrollManager(EmployeePayroll employeePayroll, ILocationItemRatesProvider_Get rateProvider, IDeductionChargeCalculator chargeCalculator)
        {
            _employeePayroll=employeePayroll;
            _rateProvider=rateProvider;
            _chargeCalculator=chargeCalculator;
        }

        /// <summary>
        /// Get deduction charge amount on each item for printing.
        /// </summary>
        /// <returns>string</returns>
        public virtual string GetDeductionChargeDetailInfo()
        {
            bool IsLocationExisted = _rateProvider.IsLocationExisted(_employeePayroll.Location);
            if (IsLocationExisted)
            {
                IList<ItemRates> itemRatesList = _rateProvider.GetLocationItemRates(_employeePayroll.Location);
                IList<ItemDeduction> itemDeductions = _chargeCalculator.CalculateDeductions(_employeePayroll.GrossAmount, itemRatesList);
                StringBuilder sb = new StringBuilder();
                string printString = string.Empty;
                sb.AppendLine(string.Format("Employee location: {0}\r\n", _employeePayroll.Location));
                sb.AppendLine(string.Format("Gross Amount:{0:C}\r\n", _employeePayroll.GrossAmount));
                sb.AppendLine("Less deductions:\r\n");
                decimal totalDeductionChargeAmt = itemDeductions.TotalChargeAmount();
                sb.Append(itemDeductions.ExtendedToString());
                sb.AppendLine(string.Format("Net Amount:{0:C}", _employeePayroll.GrossAmount - totalDeductionChargeAmt));
                printString = sb.ToString();
                return printString;
            }
            else
                throw new Exception(Properties.ExceptionResources.LocationNotFound);
        }
    }
}
