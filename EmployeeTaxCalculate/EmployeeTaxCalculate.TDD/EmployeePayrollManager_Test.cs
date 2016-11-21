using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTaxCalculate.TDD
{
    [TestClass]
    public class EmployeePayrollManager_Test
    {
        [TestMethod]
        public void Test_GetDeductionChargeDetailInfo()
        {
            EmployeePayroll _employeePayroll = new EmployeePayroll(40, 25, "Ireland");
            ILocationItemRatesProvider_Get _rateProvider = new LocationItemRatesProvider();
            IDeductionChargeCalculator _chargeCalculator = new DeductionChargeCalculator();
            EmployeePayrollManager _employeePayrollManager = new EmployeePayrollManager(_employeePayroll, _rateProvider, _chargeCalculator);
            string payrollDetailInfo = _employeePayrollManager.GetDeductionChargeDetailInfo();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Employee location: {0}\r\n", "Ireland"));
            sb.AppendLine(string.Format("Gross Amount:{0:C}\r\n", (decimal)1000.00));
            sb.AppendLine("Less deductions:\r\n");

            sb.AppendLine(string.Format("{0}:{1:C}", "Income Tax", (decimal)310.00));
            sb.AppendLine(string.Format("{0}:{1:C}", "Universal Social Charge", (decimal)75.00));
            sb.AppendLine(string.Format("{0}:{1:C}", "Pension", (decimal)40.00));

            sb.AppendLine(string.Format("Net Amount:{0:C}", (decimal)575.00));
            Assert.AreEqual(sb.ToString(), payrollDetailInfo);
        }
    }
}
