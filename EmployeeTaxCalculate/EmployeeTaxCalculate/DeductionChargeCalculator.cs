using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    /// <summary>
    /// 
    /// </summary>
    public class DeductionChargeCalculator : IDeductionChargeCalculator
    {
        /// <summary>
        /// Calculate deduction charge amount on one item.
        /// </summary>
        /// <param name="grossAmount">Gross Amount</param>
        /// <param name="itemRates">Rates of one deduction item</param>
        /// <returns></returns>
        private ItemDeduction CalculateDeduction(decimal grossAmount, ItemRates itemRates)
        {
            decimal totalDudution = 0;
            decimal remaining = grossAmount;
            int currentRateId = 0;
            while (remaining > 0)
            {
                var rate = itemRates.Rates[currentRateId];
                decimal taxable = Math.Min(rate.MaxValue, remaining);
                decimal taxForThisRate = (taxable * rate.Percent) / 100;
                totalDudution += taxForThisRate;
                remaining -= rate.MaxValue;
                currentRateId++;
            }
            return new ItemDeduction(itemRates.ItemName, totalDudution);
        }

        /// <summary>
        /// Iterately calculate deduction charge for all deduction items.
        /// </summary>
        /// <param name="grossAmount"> Gross Amount</param>
        /// <param name="itemRatesList">Rates of all deduction items</param>
        /// <returns></returns>
        public IList<ItemDeduction> CalculateDeductions(decimal grossAmount, IList<ItemRates> itemRatesList)
        {
            IList<ItemDeduction> itemDeductions = new List<ItemDeduction>();
            foreach (var itemRates in itemRatesList)
            {
                itemDeductions.Add(CalculateDeduction(grossAmount, itemRates));
            }
            return itemDeductions;
        }
    }
}
