using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeTaxCalculate;
using System.Collections.Generic;

namespace EmployeeTaxCalculate.TDD
{
    [TestClass]
    public class LocationItemRatesProvider_Test
    {
        [TestMethod]
        public void Test_IsLocationExisted()
        {
            ILocationItemRatesProvider_Get rateprovider = new LocationItemRatesProvider();
            bool italy = rateprovider.IsLocationExisted("italy");
            Assert.AreEqual(true, italy);
            bool Ireland = rateprovider.IsLocationExisted("Ireland");
            Assert.AreEqual(true, Ireland);
            bool germany = rateprovider.IsLocationExisted("germany");
            Assert.AreEqual(true, germany);
            bool usa = rateprovider.IsLocationExisted("japan");
            Assert.AreEqual(false, usa);
        }

        [TestMethod]
        public void Test_GetLocationItemRates()
        {
            ILocationItemRatesProvider_Get rateprovider = new LocationItemRatesProvider();
            IList<ItemRates> itemRates = rateprovider.GetLocationItemRates("Ireland");
            Assert.AreEqual(3, itemRates.Count);
            Assert.AreEqual("Income Tax", itemRates[0].ItemName);
            Assert.AreEqual((decimal)0.00, itemRates[0].Rates[0].MinValue);
            Assert.AreEqual((decimal)600.00, itemRates[0].Rates[0].MaxValue);
            Assert.AreEqual((decimal)25, itemRates[0].Rates[0].Percent);
            Assert.AreEqual((decimal)601.00, itemRates[0].Rates[1].MinValue);
            Assert.AreEqual(decimal.MaxValue, itemRates[0].Rates[1].MaxValue);
            Assert.AreEqual((decimal)40, itemRates[0].Rates[1].Percent);

            Assert.AreEqual("Universal Social Charge", itemRates[1].ItemName);
            Assert.AreEqual((decimal)0.00, itemRates[1].Rates[0].MinValue);
            Assert.AreEqual((decimal)500.00, itemRates[1].Rates[0].MaxValue);
            Assert.AreEqual((decimal)7, itemRates[1].Rates[0].Percent);
            Assert.AreEqual((decimal)501.00, itemRates[1].Rates[1].MinValue);
            Assert.AreEqual(decimal.MaxValue, itemRates[1].Rates[1].MaxValue);
            Assert.AreEqual((decimal)8, itemRates[1].Rates[1].Percent);

            Assert.AreEqual("Pension", itemRates[2].ItemName);
            Assert.AreEqual((decimal)0.00, itemRates[2].Rates[0].MinValue);
            Assert.AreEqual(decimal.MaxValue, itemRates[2].Rates[0].MaxValue);
            Assert.AreEqual((decimal)4, itemRates[2].Rates[0].Percent);

        }

        [TestMethod]
        public void Test_SetLocationItemRates()
        {
            LocationItemRatesProvider rateprovider = new LocationItemRatesProvider();
            //add new location
             rateprovider.SetLocationItemRates("Usa",
             new[]
                    {
                        new ItemRates("Income Tax",new [] 
                            {
                                new Rate((decimal)0.00,(decimal)600.00,(decimal)25),
                                new Rate((decimal)601.00, decimal.MaxValue,(decimal)40)
                            })
              });
            IList<ItemRates> userItemRates = rateprovider.GetLocationItemRates("usa");
            Assert.AreNotEqual(null, userItemRates);
            Assert.AreEqual(1, userItemRates.Count);
            Assert.AreEqual("Income Tax", userItemRates[0].ItemName);
            Assert.AreEqual((decimal)0.00, userItemRates[0].Rates[0].MinValue);
            Assert.AreEqual((decimal)600.00, userItemRates[0].Rates[0].MaxValue);
            Assert.AreEqual((decimal)25, userItemRates[0].Rates[0].Percent);
            Assert.AreEqual((decimal)601.00, userItemRates[0].Rates[1].MinValue);
            Assert.AreEqual(decimal.MaxValue, userItemRates[0].Rates[1].MaxValue);
            Assert.AreEqual((decimal)40, userItemRates[0].Rates[1].Percent);
            
            //update existing location.
            rateprovider.SetLocationItemRates("Germany", new[]
                    {
                        new ItemRates("Income Tax",new [] 
                            {
                                new Rate((decimal)0.00,(decimal)600.00,(decimal)25),
                                new Rate((decimal)601.00, decimal.MaxValue,(decimal)40)
                            })
              });
            IList<ItemRates> germanyItemRates = rateprovider.GetLocationItemRates("Germany");
            Assert.AreNotEqual(null, germanyItemRates);
            Assert.AreEqual(1, germanyItemRates.Count);
            Assert.AreEqual("Income Tax", germanyItemRates[0].ItemName);
            Assert.AreEqual((decimal)0.00, germanyItemRates[0].Rates[0].MinValue);
            Assert.AreEqual((decimal)600.00, germanyItemRates[0].Rates[0].MaxValue);
            Assert.AreEqual((decimal)25, germanyItemRates[0].Rates[0].Percent);
            Assert.AreEqual((decimal)601.00, germanyItemRates[0].Rates[1].MinValue);
            Assert.AreEqual(decimal.MaxValue, germanyItemRates[0].Rates[1].MaxValue);
            Assert.AreEqual((decimal)40, germanyItemRates[0].Rates[1].Percent);
          }
    }
}
