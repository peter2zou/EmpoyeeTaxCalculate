using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeTaxCalculate;
using System.Collections.Generic;

namespace EmployeeTaxCalculate.TDD
{
    [TestClass]
    public class DeductionChargeCalculator_Test
    {
        [TestMethod]
        public void Test_CalculateDeduction()
        {
            decimal grossAmount=(decimal)1000;
            ItemRates itemRates = new ItemRates("Income Tax", new[] 
                            {
                                new Rate((decimal)0.00,(decimal)600.00,(decimal)25),
                                new Rate((decimal)601.00, decimal.MaxValue,(decimal)40)
                            });
            IDeductionChargeCalculator chargeCalculator = new DeductionChargeCalculator();
            PrivateObject obj = new PrivateObject(chargeCalculator);
            ItemDeduction itemDedution = (ItemDeduction)obj.Invoke("CalculateDeduction", grossAmount, itemRates);
            Assert.AreEqual("Income Tax", itemDedution.DeductionItemName);
            Assert.AreEqual((decimal)310,itemDedution.DeductionCharge);
        }


        [TestMethod]
        public void Test_CalculateDeductions()
        {
            decimal grossAmount = (decimal)1000;
            IList<ItemRates> itemRates = new[]
                    {
                        new ItemRates("Income Tax",new [] 
                            {
                                new Rate((decimal)0.00,(decimal)600.00,(decimal)25),
                                new Rate((decimal)601.00, decimal.MaxValue,(decimal)40)
                            }),
                        new ItemRates("Universal Social Charge",new[] 
                            {
                                new Rate((decimal)0.00,(decimal)500.00,(decimal)7),
                                new Rate((decimal)501.00, decimal.MaxValue,(decimal)8)
                            })
                    };
            IDeductionChargeCalculator chargeCalculator = new DeductionChargeCalculator();
            IList<ItemDeduction> itemDeductions=chargeCalculator.CalculateDeductions(grossAmount, itemRates);
            Assert.AreEqual(2, itemDeductions.Count);
            Assert.AreEqual("Income Tax", itemDeductions[0].DeductionItemName);
            Assert.AreEqual((decimal)310, itemDeductions[0].DeductionCharge);
            Assert.AreEqual("Universal Social Charge", itemDeductions[1].DeductionItemName);
            Assert.AreEqual((decimal)75, itemDeductions[1].DeductionCharge);
        }
    }

}
