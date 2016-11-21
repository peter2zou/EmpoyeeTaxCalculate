using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    class Program
    {
       
        static void Main()
        {
            bool isExit=false;            
            do
            {
                Console.WriteLine("Please Enter Below Information([Ctrl+C] to exit):\r\n");
                decimal hours = Utilities.InputData<decimal>("Please enter the hours worked:");
                decimal rate = Utilities.InputData<decimal>("Please enter the hourly rate:");
                string location = Utilities.InputData<string>("Please enter the employees location:");

                PrintEmployeePayroll(hours, rate, location);

                string isContinue = Utilities.InputData<string>("\nDo you want to continue(Y/N)?");
                if (isContinue.Trim().ToUpper() == "N") isExit = true;
                else
                    Console.Clear();
            } while (!isExit);
         }

        /// <summary>
        /// Create EmployeePayrollManager object by passing all dependency injections and run GetDeductionChargeDetailInfo method to get all Deduction Charge on each item level.
        /// </summary>
        /// <param name="hours">Hours</param>
        /// <param name="rate">Rate</param>
        /// <param name="location">Location Name</param>
        private static void PrintEmployeePayroll(decimal hours, decimal rate, string location)
        {
            try
            {
                EmployeePayroll employeePayroll = new EmployeePayroll(hours, rate, location);
                ILocationItemRatesProvider_Get rateProvider=new LocationItemRatesProvider();
                IDeductionChargeCalculator chargeCalculator = new DeductionChargeCalculator();
                EmployeePayrollManager employeePayrollManager = new EmployeePayrollManager(employeePayroll, rateProvider, chargeCalculator);
                string payrollDetailInfo = employeePayrollManager.GetDeductionChargeDetailInfo();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(payrollDetailInfo);
                Console.WriteLine("------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
}
    