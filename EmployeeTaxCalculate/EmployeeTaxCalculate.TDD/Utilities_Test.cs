using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTaxCalculate.TDD
{
    [TestClass]
    public class Utilities_Test
    {
        [TestMethod]
        public void Test_ExtendedToStringForIListOfItemDeduction()
        {
            IList<ItemDeduction> itemDeductions = new[]
            {
                new ItemDeduction("Income Tax",(decimal)310),
                new ItemDeduction("Universal Social Charge",(decimal)75)
            };
            
            string result=itemDeductions.ExtendedToString();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0}:{1:C}", "Income Tax", (decimal)310.00));
            sb.AppendLine(string.Format("{0}:{1:C}", "Universal Social Charge", (decimal)75.00));

            Assert.AreEqual(sb.ToString(),result);
        }


        [TestMethod]
        public void Test_ExtendedToStringForItemDeduction()
        {
            ItemDeduction itemDeduction = new ItemDeduction("Income Tax", (decimal)310);

            string result = itemDeduction.ExtendedToString();

            string shouldbe=string.Format("{0}:{1:C}", "Income Tax", (decimal)310.00);

            Assert.AreEqual(shouldbe, result);
        }

        [TestMethod]
        public void Test_TotalChargeAmountForIListOfItemDeduction()
        {
            IList<ItemDeduction> itemDeductions = new[]
            {
                new ItemDeduction("Income Tax",(decimal)310),
                new ItemDeduction("Universal Social Charge",(decimal)75)
            };

            decimal result = itemDeductions.TotalChargeAmount();

            Assert.AreEqual((decimal)385, result);
        }

    }
}
